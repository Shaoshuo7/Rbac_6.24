using AutoMapper;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AdminService : BaseService<Admin, AdminDto>, IAdminService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IAdminAndRoleRepository adminAndRoleRepository;

        public AdminService(IAdminRepository adminRepository, IMapper mapper, IConfiguration configuration, IAdminAndRoleRepository adminAndRoleRepository)
            : base(adminRepository, mapper)
        {
            this.adminRepository = adminRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.adminAndRoleRepository = adminAndRoleRepository;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public ResultDto AdminAdd(AdminDto c)
        {
            if (adminRepository.FanT(t=>t.AdmName == c.AdmName.Trim().ToLower()) !=null)
            {
                return new ResultDto { Code = 1, Msg = "已经存在该用户" };
            }

            c.AdmName = c.AdmName.Trim().ToUpper();
            c.AdmPassWord = Md5(c.AdmPassWord.Trim());
            c.CreateTime = DateTime.Now;
            c.LastDateTime = DateTime.Now;

            adminRepository.Add(mapper.Map<Admin>(c));

            return new ResultDto { Code = 0, Msg = "注册成功" };
        }

        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }

        /// <summary>
        /// 登录  含令牌
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public TokenDto AdmLogin(LoginDto c)
        {
            var adm = adminRepository.FanT(t => t.AdmName == c.AdmName.Trim());
            if (adm == null)
            {
                return new TokenDto { Code = 1, Msg = "没有此用户" };
            }
            if (adm.AdmPassWord.ToLower() != Md5(c.AdmPassWord.Trim().ToLower()))
            {
                return new TokenDto { Code = 2, Msg = "密码错误" };
            }

            //生成Token令牌
            IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, c.AdmName)
            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));

            //算法，签名证书
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);


            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"], //发布者、颁发者
                audience: configuration["JwtConfig:Audience"],  //令牌接收者
                claims: claims, //自定义声明信息
                notBefore: DateTime.UtcNow,  //创建时间
                expires: expires,   //过期时间
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new TokenDto { Code = 0, Msg = "登陆成功", Token = jwt };
        }

        public ResultPage<AdminDto> Paginations(Pager dto)
        {
            var list = adminRepository.MeunAll().AsQueryable();

            var count = list.Count();

            var query = list.OrderBy(t => t.AdminId).Skip((dto.Page - 1) * dto.Size).Take(dto.Size).ToList();

            ResultPage<AdminDto> result = new ResultPage<AdminDto>();
            
            result.TotalCount = count;
            result.Data = mapper.Map<List<AdminDto>>(query);

            return result;
        }

        public ResultDto Permis(AdminDto c)
        {
            if (adminRepository.FanT(t => t.AdmName == c.AdmName.Trim().ToLower()) != null)
            {
                return new ResultDto { Code = 1, Msg = "已经存在该用户" };
            }

            c.AdmName = c.AdmName.Trim().ToUpper();
            c.AdmPassWord = Md5(c.AdmPassWord.Trim());
            c.CreateTime = DateTime.Now;
            c.LastDateTime = DateTime.Now;

            var Entity = mapper.Map<Admin>(c);

            adminRepository.Add(Entity);

            var list = c.RoleId.Select(t => new AdminAndRole { RoleId = t, AdminId = Entity.AdminId }).ToList();

            adminAndRoleRepository.Add(list);

            return new ResultDto { Code = 0, Msg = "注册成功" };
        }
    }
}
