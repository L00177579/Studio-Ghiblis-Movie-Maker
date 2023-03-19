<a name='assembly'></a>
# StudioGhibliMovieMaker

## Contents

- [PasswordEncryption](#T-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption 'StudioGhibliMovieMaker.BusinessObjects.Encryption.PasswordEncryption')
  - [ComparePassword(plainTextPassword,hashedPassword,salt)](#M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-ComparePassword-System-String,System-String,System-String- 'StudioGhibliMovieMaker.BusinessObjects.Encryption.PasswordEncryption.ComparePassword(System.String,System.String,System.String)')
  - [GeneratePasswordHash(password,salt)](#M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-GeneratePasswordHash-System-String,System-String- 'StudioGhibliMovieMaker.BusinessObjects.Encryption.PasswordEncryption.GeneratePasswordHash(System.String,System.String)')
  - [GenerateSalt(byteSize)](#M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-GenerateSalt-System-Int32- 'StudioGhibliMovieMaker.BusinessObjects.Encryption.PasswordEncryption.GenerateSalt(System.Int32)')

<a name='T-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption'></a>
## PasswordEncryption `type`

##### Namespace

StudioGhibliMovieMaker.BusinessObjects.Encryption

<a name='M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-ComparePassword-System-String,System-String,System-String-'></a>
### ComparePassword(plainTextPassword,hashedPassword,salt) `method`

##### Summary

Compares a plaintext password and a hashed password using the salt.

`plainTextPassword` is the users plain text password that will be hashed using the passed in salt.

`hashedPassword` is the pre-hashed password.

`salt` is the salt that will be used to hash the plaintext password

##### Returns

True if the plain text password when hashed is equivalent to the supplied hashed password. False otherwise.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| plainTextPassword | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The plain text password. |
| hashedPassword | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The hashed password. |
| salt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The salt. |

<a name='M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-GeneratePasswordHash-System-String,System-String-'></a>
### GeneratePasswordHash(password,salt) `method`

##### Summary

Generates a hash of a plain text password using SHA256 encryption and a supplied salt.

`password` is the users plain text password that will be hashed using the passed in salt.

`salt` is the salt that will be used to hash the plaintext password.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The plain text password. |
| salt | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The salt. |

<a name='M-StudioGhibliMovieMaker-BusinessObjects-Encryption-PasswordEncryption-GenerateSalt-System-Int32-'></a>
### GenerateSalt(byteSize) `method`

##### Summary

Generate a salt as a Base64String.

`byteSize` refers to the size of the byte array that will be filled by the random number generator.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| byteSize | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The size of the byte array. |
