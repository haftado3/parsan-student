# Parsan-Student
This is a simple crud operation on student table which is authorized.

# 1 - Get Identity Server Runing :

more about this in :
https://github.com/haftado3/parsan_auth


# 2 - Clone This Repository :

execute `git clone https://github.com/haftado3/parsan-student.git` to clone this library.
 
# 3 - Connection String :

connection string is inside `appsettings.json`. in case you dont have Sql Server Express you need to change Connection String.

# 4 - Update Migrations :


in case you dont have dotnet-ef 

`install dotnet-ef global for dotnet cli`

then 

`dotnet ef database update`


# 5 - Run App :

make sure you have parsan_auth API running on background before this.

then :

`dotnet run`

this will run app on `https://localhost:5050` which can be configured inside `launchSettings.json`

# 6 - PostMan Import :

import post man json file included at `  sd`

send a get request to https://localhost:5050/api/auth  already included in postman with name of `Get Token`.
which will give you a Bearer Token .

# 7 - Add Token To PostMan :

add Bearer Auth Recieved From previous section to All Other Reqeuests inside `Authorization -> Token` with `Authorization -> Type` of `Bearer Token`.

# 8 - Send Anyone Of Existed Requests.

token will expire in 1 hour.
