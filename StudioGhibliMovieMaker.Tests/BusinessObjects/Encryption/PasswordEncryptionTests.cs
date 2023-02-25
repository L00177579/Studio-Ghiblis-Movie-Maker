using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudioGhibliMovieMaker.BusinessObjects.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGhibliMovieMaker.BusinessObjects.Encryption.Tests
{
    [TestClass()]
    public class PasswordEncryptionTests
    {
        private readonly PasswordEncryption _passwordEncryption;

        public PasswordEncryptionTests()
        {
            _passwordEncryption = new PasswordEncryption();
        }

        [TestMethod()]
        [DataRow("Test", "tFaTu5rDkV2M2X0gJ+gsFbF/SwqLwiuLm4yBla6OlDyYkEMj83xpHsgaBhUmnjrtaTXwFPYrgxUj8uAP8fhdGg==", "iDSW2RYGWlJ+3mDMZhc2Ia11tC6Ej1LGDMx3OZgcQwA=")]
        [DataRow("Test", "qYm0nsHD4+R4OAuOrWOF4sKQqz2lpqwT8qyLFeBqt8FrQqWRnMk4wb4IpLUMyQOLtoffjHng6LO+1MmUilzz5g==", "uNNUI/tFFYzSA/RondZjJaGJrE2lgi0u/0of/oUwE2E=")]
        [DataRow("Test", "pEMieZB8Ly3CDFvPfL4/i+A2gcbmhgb1e4Nc1/FW5f+k6FIQZujpmT/Na5e2kFIRs6zkeJYEWnFmL/j2e7NRTA==", "+LuBhvklC8e2m/iQAjN7Lvc7vwqDudBxSm8AytLFENI=")]
        [DataRow("Test", "PnILWoHADdtXdIOec840BXslN0c34yHUtuKv9MaJVbsMoxdWXfpdBbHBuoOKaEL92QbGRD4TQ8yAcwJfbDgx2A==", "E7YG/HsPY31FRCZubItP+xvdE4vD3V2IEMoFFkMujVc=")]
        [DataRow("Test", "ONWFcT/KjdRNNvuSD9ZzQW1qNLJOK+kjcXASRsAVBpry4fpPqD84bGIUdr+we5E6t1aF96/gQkC329GwosqMJw==", "pqiaSufZmGJTGheAZ+EeBsmyU1lR6paX1y0Dnf8C948=")]
        [DataRow("Test", "CcBYfZ8t5ffqTo61b7ZFQRrgmuFPWKHK73oKWVJBMfvs30q5d3x8JDMsWj1HiExQFsrG27wEkdXzs/nFb86dkw==", "bZfebUo/uDmTOyaPM8BBIlOHBmqLCzg2odjXZ1/nqX0=")]
        [DataRow("Test", "1O5Z7qwd5WsPaRSIiEdTqt5Hk7EgeysspWFVA6axHpvySzOS+/K7mz0a3n8+HswFRVbwLKfGq/EosO1jBgRKhA==", "gINWneQZoOa7HhKhJAVJcDRTptXQYI+H61Iqe7htCLk=")]
        [DataRow("Test", "0mebIEStQdNxYf+HSOv98XlukLxrvumnR6k0vJHIiN7dJfM6Z3/z6RwNB58pfRh4adGxZ0hNg/86ofPcBKe4Kw==", "KaDHHIusr2L28j/JAshn1IcdfkmPKahIqmhYTNwQlhg=")]
        [DataRow("Test", "mn0MRdLKl5DnwtcUKQrxnohc6CWXnmQOaN591Zg8dv4wvgYMtgVWGh2mhzFNt3myW0908Fw2Euh7J/bMHseggw==", "0q0W15ajckHhdRMK11eD+PtoxLpkMqrJAjNDGayJVgc=")]
        [DataRow("Test", "1crDE5afBnVkDQzitr6XP2xThL9U+BtA40gSyqlOcvyMgiFnv0AW5whYmBiOFWwU6MAvd9NTtqykbkgmXZN+Jg==", "4TEAZ3qwTvh8/1+tl/gKi1RztQVOf6U11oYbrUHPvQs=")]
        public void PasswordEncryptionTest_GeneratePasswordHash(string password, string salt, string expected)
        {
            var actual = this._passwordEncryption.GeneratePasswordHash(password, salt);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        [DataRow("Test", "tFaTu5rDkV2M2X0gJ+gsFbF/SwqLwiuLm4yBla6OlDyYkEMj83xpHsgaBhUmnjrtaTXwFPYrgxUj8uAP8fhdGg==", "iDSW2RYGWlJ+3mDMZhc2Ia11tC6Ej1LGDMx3OZgcQwA=")]
        [DataRow("Test", "qYm0nsHD4+R4OAuOrWOF4sKQqz2lpqwT8qyLFeBqt8FrQqWRnMk4wb4IpLUMyQOLtoffjHng6LO+1MmUilzz5g==", "uNNUI/tFFYzSA/RondZjJaGJrE2lgi0u/0of/oUwE2E=")]
        [DataRow("Test", "pEMieZB8Ly3CDFvPfL4/i+A2gcbmhgb1e4Nc1/FW5f+k6FIQZujpmT/Na5e2kFIRs6zkeJYEWnFmL/j2e7NRTA==", "+LuBhvklC8e2m/iQAjN7Lvc7vwqDudBxSm8AytLFENI=")]
        [DataRow("Test", "PnILWoHADdtXdIOec840BXslN0c34yHUtuKv9MaJVbsMoxdWXfpdBbHBuoOKaEL92QbGRD4TQ8yAcwJfbDgx2A==", "E7YG/HsPY31FRCZubItP+xvdE4vD3V2IEMoFFkMujVc=")]
        [DataRow("Test", "ONWFcT/KjdRNNvuSD9ZzQW1qNLJOK+kjcXASRsAVBpry4fpPqD84bGIUdr+we5E6t1aF96/gQkC329GwosqMJw==", "pqiaSufZmGJTGheAZ+EeBsmyU1lR6paX1y0Dnf8C948=")]
        [DataRow("Test", "CcBYfZ8t5ffqTo61b7ZFQRrgmuFPWKHK73oKWVJBMfvs30q5d3x8JDMsWj1HiExQFsrG27wEkdXzs/nFb86dkw==", "bZfebUo/uDmTOyaPM8BBIlOHBmqLCzg2odjXZ1/nqX0=")]
        [DataRow("Test", "1O5Z7qwd5WsPaRSIiEdTqt5Hk7EgeysspWFVA6axHpvySzOS+/K7mz0a3n8+HswFRVbwLKfGq/EosO1jBgRKhA==", "gINWneQZoOa7HhKhJAVJcDRTptXQYI+H61Iqe7htCLk=")]
        [DataRow("Test", "0mebIEStQdNxYf+HSOv98XlukLxrvumnR6k0vJHIiN7dJfM6Z3/z6RwNB58pfRh4adGxZ0hNg/86ofPcBKe4Kw==", "KaDHHIusr2L28j/JAshn1IcdfkmPKahIqmhYTNwQlhg=")]
        [DataRow("Test", "mn0MRdLKl5DnwtcUKQrxnohc6CWXnmQOaN591Zg8dv4wvgYMtgVWGh2mhzFNt3myW0908Fw2Euh7J/bMHseggw==", "0q0W15ajckHhdRMK11eD+PtoxLpkMqrJAjNDGayJVgc=")]
        [DataRow("Test", "1crDE5afBnVkDQzitr6XP2xThL9U+BtA40gSyqlOcvyMgiFnv0AW5whYmBiOFWwU6MAvd9NTtqykbkgmXZN+Jg==", "4TEAZ3qwTvh8/1+tl/gKi1RztQVOf6U11oYbrUHPvQs=")]
        public void PasswordEncryptionTest_ComparePassword(string plainTextPassword, string salt, string hashedPassword)
        {
            var actual = this._passwordEncryption.ComparePassword(plainTextPassword, hashedPassword, salt);


            Assert.IsTrue(actual);
        }
    }
}