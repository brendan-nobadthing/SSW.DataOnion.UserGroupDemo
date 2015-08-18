
rem run this from the developer command prompt

rem todo: update to https:// url
msbuild ..\SSW.DataOnion.UserGroupDemo.sln /t:Build /p:RunOctoPack=true /p:OctoPackPublishPackageToHttp=http://octopus.ssw.com.au:8081/nuget/packages /p:OctoPackPublishApiKey=API-VPCIKFIVNNC8JG6ZZCSNLVPNL8