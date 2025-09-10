# ShopCMS
![ShopCMS Project Image](/_readme_images/ShopCMS.png "ShopCMS Project Image")
## Table of Contents
1. [Introduction](#introduction)
2. [Tech Stack](#tech-stack)
3. [Features](#features)
4. [Quick Start](#quick-start)
5. [References](#references)

## <a name="introduction">Introduction</a>
This project provided hands-on experience in ASP.NET Core and Blazor web development, starting with understanding the basics and resulting in the creation of a useful content management system (CMS) for a shop or supermarket. Additionally, the project delved into the utilization of SQL Server for database management and leveraged Azure for hosting both the website and databases.

## <a name="tech-stack">Tech Stack</a>
- C#
- ASP.NET Core
- ASP.NET Razor
- Blazor
- Entity Framework Core
- SignalR 
- ASP.NET Identity
- SQL Server
- Azure
- Bootstrap
- jQuery
- Tabler Icons
- SCSS

## <a name="features">Features</a>
- **ASP.NET Core and Blazor Integration**: Utilized ASP.NET Core and Blazor for robust backend development.
- **Entity Framework Core SQL Server**: Uses a powerful database solution using Entity Framework Core with SQL Server.
- **Use Case Driven Development**: Adopted a use case-driven development approach for systematic implementation.
- **Clean Architecture Implementation**: Developed using clean architecture principles for a modular and maintainable approach and code.
- **ASP.NET Core Identity for Authentication**: Employed ASP.NET Core Identity for secure authentication and authorization.
- **Admin Functionality**: Log in as an admin to manage product categories, add new categories, and edit products.
- **Product and Category Management**: Add, edit, and delete products and categories for effective inventory control.
- **Cashier Functionality**: Log in as a cashier to process product sales and view daily transactions.
- **Transaction Reports for Admin**: Access transaction reports as an admin, filtering by different days and cashiers.
- **Printable Transaction Reports**: Print transaction reports with customizable options or save them to PDF.
- **Implementation of a modern CMS interface:** Adapted an eye-catching and elegantly designed admin template using Bootstrap from Admin Mart.
- **Responsive Design:** The application is optimized for seamless user experience across various devices.

## <a name="quick-start">Quick Start</a>
NOTE: These steps are accurate as of March 2024. Over time, certain tasks may change or use renamed labels. If this occurs while following a step, please access current documentation to work out what has changed and find equivalent approaches to the step.

### Step 1: Software installation and workload setup
1. Install the following software:
    * Microsoft SQL Server Management Studio (SSMS)
        * Version 19.3 was used during development.
    * Microsoft Visual Studio
        * Community 2022, Version 17.9.0 was used during development.
2. In Visual Studio, install the following workloads (either during the initial installation, or by opening the "Visual Studio Installer" program and clicking "Modify" on the currently installed version of Visual Studio):
    * ASP.NET and web development
    * .NET desktop development
3. Create and/or log into an Azure account. Make sure you have a valid subscription (either paid or free).

### Step 2: Create the resource group in Azure
1. Access the  __Resource groups__ service. If it is not on the home page, use the search bar within the navigation bar. This will open the __Resource groups__ page.
2. In the command bar, click __Create__. This opens the __Create SQL Database__ page.
    1. Within __Basics__:
        * Set the __Resource group__ to ```ShopCMS```.
    2. Within __Resource details__:
        * Choose a recommended __Region__ that is closest to you.
3. With __Tags__, nothing will be changed. Click the __Review + create__ button, and then click the __Create__ button. This will return back to the __Resource groups__ page. Wait for the resource group to be created.

### Step 3: Create SQL database in Azure
1. Access the  __SQL databases__ service. If it is not on the home page, use the search bar within the navigation bar.
2. In the command bar, click __Create__. This opens the __Create SQL Database__ page.
    1. Within __Basics__:
        1. Within __Project details__: 
            * Set the __Resource group__ to ```ShopCMS```.
        2. Within __Database details__:
            * Set __Database name__ to ```ShopCMS_MarketDB```
            * Create a new __Server__ by clicking the __Create new__ link. This opens the __Create SQL Database Server__ page.
                1. Within __Server details__:
                    * Set the __Server name__ to a unique valid value based on the rules that Azure will display while entering the value.
                    * Choose a recommended __Location__ that is closest to you, preferably the one used for the resource group.
                2. Within __Authentication__:
                    * Set __Authentication method__ to ``Use SQL authentication``
                    * Set __Server admin login__, __Password__ and __Confirm password__ to valid values based on the rules that Azure will display while entering the values. Make a note of these for future reference.
                3. Click __OK__ to get back to the __Create SQL Database__ page.
            * Set __Workload environment__ to ``Development``, since it costs less.
            * Configure the database for __Compute + storage__ by clicking __Configure database__. This opens the __Configure__ page.
                1. Within __Auto-pause delay__
                    * Set __Data max size (GB)__ to the lowest value. As of writing, this is `1`.
                2. Click __Apply__ to go back to the __Create SQL Database__ page.
        3. Within __Backup storage redundancy__
            * Set __Backup storage redundancy__ to ``Locally-redundant backup storage``
        4. Click the __Next : Networking__ button
    2. Within __Networking__:
        1. Within __Network connectivity__"
            * Set __Connectivity method__ to ``Public endpoint``
        2. Click the __Next : Security__ button
    3. With __Security__, __Additional settings__ and __Tags__, nothing will be changed. Click the __Review + create__ button, and then click the __Create__ button. This opens a page for the database __Deployment__. Wait for the database to deploy.
3. Create another database for the accounts. Repeat this step, but:
    1. Within __Basics__:
        1. Within __Database details__:
            1. Set the __Database name__ to ```ShopCMS_AccountDB```
            2. Reuse the server you created 
    2. Within __Networking__, the __Connectivity method__ does not appear, so do not change anything.
    
### Step 4: Connect the databases to the Visual Studio solutions
1. For each database, go to Azure and get the connection strings.
    1. Once the deployment is complete for a database, click the __Go to resource__ button. This opens a page for the SQL database.
        * In the sidebar, under __Settings__, click the __Connection strings__ option
        * You will be using the connection strings under __ADO.NET (SQL authentication)__
2. Go to the solution open in Visual Studio and create development app settings
    1. Inside the root of the __WebApp__ project folder, create a new file named __appsettings.Development.json__. Add the following template and replace the placeholder strings with the corresponding __ADO.NET (SQL authentication)__ connection strings.
        ```
        {
            "ConnectionStrings": {
                "DefaultConnection": "market_database_connection_string",
                "AccountContextConnection": "account_database_connection_string"
            },
            "DetailedErrors": true,
            "Logging": {
                "LogLevel": {
                    "Default": "Information",
                    "Microsoft": "Warning",
                    "Microsoft.Hosting.Lifetime": "Information"
                }
            }
        }
        ```
    2. By default, the value for __Password__ in both connection strings will be a placeholder (such as ```{your_password}```). In __appsettings.Development.json__, replace these placeholders with the database server admin password.
3. In the navigation bar, click __View__, then __Server Explorer__
4. Left click on __Data Connections__ and click __Add Connection__
5. Within the __Add Connection__ dialog box
	1. Set __Data source__ to ``Microsoft SQL Server (SqlClient)``
	2. Set __Server name__ to the ``Server=tcp`` value from the connection strings
	3. Within the __Log on to the server__ section.
		* Set __Authentication__ to ``SQL Server Authentication``
		* Set the __User name__ and __Password__ to the respective values you gave for __Server admin login__ and __Password__ while creating the database.
6. In the navigation bar, open __Tools__, then __NuGet Package Manager__, then __Package Manager Console__
    1. For ShopCMS_MarketDB
        1. Switch the __Default project__ to __Plugins.DataStore.SQL__
        2. Type in the following commands:
            ```
            Add-Migration Init -Context MarketContext
            ```
            ```
            Update-Database -Context MarketContext
            ```
    1. For ShopCMS_AccountDB
        1. Switch the __Default project__ to __WebApp__
        2. Type in the following commands:
            ```
            Add-Migration CreateIdentitySchema -Context AccountContext
            ```
            ```
            Update-Database -Context AccountContext
            ```

### Step 5: Create example accounts
1. In Visual Studio, run the web app, and go to the __Register__ link. 
    1. Create two accounts: one with ``admin@test.com`` as the email and one with ``cashier@test.com`` as the email. If the password is invalid, the web app will provide feedback on what needs to be fixed for a valid password. An example of a valid password is ``Apple_No5``.
    2. After successfully creating an account, a page with the heading of __Register confirmation__ will appear. Click the __Click here to confirm your account__ link. This mimics a confirmation email being sent and accessed in order to confirm the account.
2. Open SQL Server Management Studio (SSMS). It will display a __Connect to Server__ dialog box.
    1. Inside the __Connect to Server__ dialog box.
        * Set __Server type__ to ``Database Engine``.
        * Set __Server name__ to the  ``Server=tcp:`` value from the connection string. It will look something like this: ``example.database.windows.net``.
        * Set __Authentication__ to ``SQL Server Authentication``.
        * Set __Login__ and __Password__ to the respective values for the database server admin.
        * Click __Connect__. This will open a __New Firewall Rule__ dialog box.
    2. You need to provide access to your IP address. There are two ways to do this:
        * Way 1: 
            1. Inside the __New Firewall Rule__ dialog box.
                1. Within __Azure account__
                    * Sign into Azure by clicking __Sign In...__. This will open up a login webpage.
                    * Pick the Microsoft account that you used for accessing Azure and creating the database.
                    * A page will display with the following text: "Authentication complete. You can return to the application. Feel free to close this browser tab.". Follow these instructions and go back to the __New Firewall Rule__ dialog box.
                2. Within __Firewall rule__
                    * Make sure __Add my client IP address__ is selected, and ensure that the IP address is correct.
                3. On the __Connect to Server__ dialog box, click __Connect__. 
        * Way 2:
            1. Go back to the Azure portal, and access the database resource (which has the type __SQL database__)
            2. Inside the sidebar, go to the __Overview__ option.
                * Under __Essentials__, click the __Server name__ link. This will open the database server (which has the type __SQL server__)
            3. Inside the sidebar, go to the __Networking__ option.
                1. Within __Firewall rules__
                    * Click __Add your client IPv4 address (your address)__
                2. Click the __Save__ button
            4. Going back to SQL Server Management Studio (SSMS)
                1. On the __New Firewall Rule__ dialog box, click __Cancel__. 
                2. On the __Connect to Server__ dialog box, click __Connect__. 
3. After logging in, go to __Object Explorer__ in SSMS:
    1. Expand the objects in the following order: 
        * Server name (looks something like this: ``example.database.windows.net``.)
        * ``Databases``
    2. You will see both databases. Expand ``ShopCMS_AccountDB``
        1. Expand the ``Tables``, and with ``Tables`` selected, go to the navigation bar, and click __New Query__.
        2. Inside the query, run each SQL query by clicking the __Execute__ button in the navigation bar. Replace the previous query with the next one:
            1. View the current users
                ```
                SELECT * FROM AspNetUsers
                ```
            2. Assign positions to users based on their ``Id`` value from the __Results__ table (replace the placeholders with the corresponding values)
                ```
                INSERT INTO AspNetUserClaims VALUES('Id_admin_email', 'Position', 'Admin')
                INSERT INTO AspNetUserClaims VALUES('Id_cashier_email', 'Position', 'Cashier')
                ```
            3. (Optional) If you forgot to confirm the accounts in the web app, run the following:
                ```
                UPDATE AspNetUsers
                SET EmailConfirmed = 1;
                SELECT * FROM AspNetUsers
                ```
        3. Close the SQL query file. Do not save it.

### Step 6: Upload to GitHub
1. In Visual Studio. a Git repository can be created in several ways, such as:
    * Clicking __Add to Source Control__ in the footer bar, then clicking __Git__.
    * Left-clicking the solution in the __Solution Explorer__, then clicking __Create Git Repository...__
    * Clicking __Git__ in the navigation bar, then clicking __Create Git Repository...__
Regardless, a __Create a Git repository__ dialog box will appear.
2. Ensure that you have logged into your GitHub account, and that __Private repository__ is ticked.
3. Click __Create and Push__ to create the repository with the initial commit.

### Step 7: Create the web app on Azure
1. In Azure, click __Create a resource__.
2. Click __Web App__. This opens the __Create SQL Database__ page.
    1. Within __Basics__
        1. Within __Project Details__
            1. Set __Resource Group__ to __ShopCMS__
        2. Within __Instance Details__
            1. Set __Name__ to a name that has not been already used.
            2. Set __Runtime stack__ to __.NET 8 (LTS)__
            3. Set __Operation System__ to __Windows__
            4. Set __Region__ to a recommended one closest to you, preferably the one used for the resource group and database server.
        2. Within __Pricing plans__
            1. Select a __Pricing plan__, if it is possible to do so. For a small demonstration, the __Free F1__ plan will do.
    2. Within __Database__
        1. Change nothing
    3. Within __Deployment__
        1. Within __GitHub Actions settings__
            1. Set __Continuous deployment__ to __Enable__
        2. Within __GitHub Actions details__
            1. Make sure you are logged into your GitHub account
            2. Set __Organization__ to __NigelThomasBell__
            3. Set __Repository__ to __ShopCMS__
            4. Set __master__
    4. Within __Networking__
        1. Change nothing
    5. Within __Monitoring__
        1. Ensure __Enable Application Insights__ is set to __Yes__
    6. Within __Tags__
        1. Change nothing
    7. Click __Review + create__ and then click __Create__
    8. Wait for the web app to deploy. Additionally, GitHub Actions will also perform a check with two jobs: __build__ and __deploy__, which can take a few minutes.
3. Once the Azure deployment and the GitHub actions check are both complete, click __Go to resource__
    1. In the sidebar, under __Settings__, click the __Connection strings__ option
    2. In tandem, in Visual Studio, have __appsettings.Development.json__ open. You will be using the key:value pairs within __ConnectionStrings__
    3. Under __Application settings__, click __New application setting__
        1. Set __Name__ to ``ASPNETCORE_ENVIRONMENT``
        2. Set __Value__ to ``Development``
    4. Create two connection strings within Azure. For each connection string.
        1. Under __Connection strings__, click __New connection string__.
        2. Set __Name__ to the corresponding key 
        3. Set __Value__ to the corresponding value
        4. Set __Type__ to ``SQLServer``
    5. In the command bar, click ``Save``, then ``Continue``.
4. Provide virtual IP address access to the database server. 
    1. In the sidebar, under __Settings__, click the __Properties__ option
    2. Copy the value for __Virtual IP address__
    3. Go __Home__ and access the __SQL server__ for the databases called ``shopcms``
    4. In the sidebar, under __Security__, click the __Networking__ option.
    5. Under __Exceptions__, tick the __Allow Azure services and resources to access this server__ option.
    6. Click __Save__
5. View the web app 
    1. Go to the sidebar, and under the top section with no heading, click the __Overview__ option
    2. Under __Essentials__, click the link either after the colon or under __Default domain__

## <a name="references">References</a>
* The project was built while learning from [this course](https://www.youtube.com/watch?v=DWrH7br4DsM) by Frank Liu.
* The interface is an adaptation of [Modernize Free Bootstrap 5 Admin Template](https://adminmart.com/product/modernize-free-bootstrap-5-admin-template/) by Admin Mart.