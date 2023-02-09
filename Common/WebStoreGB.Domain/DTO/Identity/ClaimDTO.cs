using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreGB.Domain.DTO.Identity
{
    // Claim - это некая дополнительная информация которая может быть добавлена к пользователю или роли, в которой может содержаться возрость, пол, а также дополнительные учётные данные. Если мы реализуем систему аутентификации с помощью некоторых сторонних систем(google), то информация которая представляется этими система передаётся и содержится в Клэймах. С помощью клеймов можно добавить пользователю, что пользователь является админом без добавления ему роли админа.
    public abstract class ClaimDTO: UserDTO
    {
        public IEnumerable<Claim> Claims { get; set; }
    }

    public class AddClaimDTO: ClaimDTO
    {

    }

    public class RemoveClaimDTO: ClaimDTO
    {

    }

    public class ReplaceClaimDTO: UserDTO
    {
        public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }
    }
}
