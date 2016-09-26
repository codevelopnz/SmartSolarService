# SmartSolarService
A project for the codevelop/ team

## Building & running

  - You need to run Visual Studio as administrator, so it can setup IIS to host the service.
  (Either that, or reconfigure the service to use IIS Express)
  
  - If you get error 9009 trying to run lessc - you will need to nstall lessc. 
This is probably easiest done by installing NPM, then: npm install -g lessc


Create a sql database default is Initial Catalog=Codevelop;User ID=codevelop;Password=P@ssw0rd1 on localhost
(or change DefaultConnection in web.config)
Tables will be autocreated

User is created in ApplicationDbContextInitialiser 
u: testUser
p: Password!
