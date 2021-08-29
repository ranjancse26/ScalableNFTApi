# ScalableNFTApi

The highly scalable SaaS Based NFT API for generating the NFT Artwork using custom generative algorithm. Uses NFT Storage as it's backend to persist the NFT Artwork

# Structure

![image](https://user-images.githubusercontent.com/2565797/131245117-39c9cadf-7135-4fcb-84a4-d467acba241a.png)

A .NET Core 3.1 based Web API coding with Microsoft C# Technology. Depends on "Modern.NFT" library (https://github.com/ranjancse26/ModernNFT) for building the Scalable NFT Artwork.

# How to Run?

1) You need to first register or signup on the NFT Storage and create an API Key. Please follow this link - https://nft.storage/
2) Create a JWT Token. Please follow this link - https://mkjwk.org/
3) Once you got have the above two keys, head over to the appsettings.json and update the below mentioned keys - JwtSettings:Secret and NFTStorageApiKey
```
"JwtSettings": {
    "Secret": "YourSecretKeyMakeSureToKeepItSecret",
    "Issuer": "https://localhost:44371"
  },
  "NFTStorageApiKey": ""
```
4) Clone or Dowload the Project
5) Open the Project on VS 2019
6) Click on Control F5 or Run the project on Debug mode
7) You should be able to see the API getting launched on https://localhost:44337/swagger
![image](https://user-images.githubusercontent.com/2565797/131245358-0e4a5bad-ea7d-4934-b0a0-de65dc0af0f4.png)
8) Autenticate the user with the username: test and password: test to get the bearer token
9) Use the bearer token and "Authorize" on the swagger
10) Head over to the Modern Art POST request and simply try it out.
![image](https://user-images.githubusercontent.com/2565797/131245421-7fd148cc-4409-402f-8ace-07a9c16f863b.png)

