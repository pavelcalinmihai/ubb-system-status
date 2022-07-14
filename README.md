# A basic status page for Universitatea Babeș-Bolyai of Cluj-Napoca, Romania

## Note: This is not an official repository and I've not been affiliated anyhow with the university.

# Description

The university ecosystem of websites had a power outage on July 11, 2022. So I was thinking about how hard is it to create this sort of page. This ASP.NET app doesn't use API requests or other ways to check the status of the services because, as I said, I'm not affiliated with the university. I was only creating HTTPS GET requests to retrieve if the website is up or not.

# Installation & Running

```
git clone
cd ubb-system-status
dotnet run
```

# Add/edit or delete websites

For this step, first, add/edit or delete an entry into the ```appsettings.json``` under the ```UBB``` section. Then all the other modifications need to be done on the ```HomeController.cs``` and ```Index.cshtml```.

# Contact
 
Please use this [email address](mailto:calinmihai64@gmail.com).
 
 # License
 
 None
