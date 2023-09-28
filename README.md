# NET_Assignment_3
## SQL Database and API using EntityFramework

### Connecting to SQL Server
In order to connect to the server, you are required to fill in your SQL server name. Please follow the steps below:

1. Open the `Appsettings.json` file in project root directory
2. Find the following code:

```
  "ConnectionStrings": {
    "Assignment3": "Data Source = N-NO-01-04-7501\\SQLEXPRESS; Initial Catalog = Assignment_3; Integrated Security = true; Trust Server Certificate = true"
  }
 ```

3. Look to the `Data Source`
4. Switch `"N-NO-01-04-1770\\SQLEXPRESS"` to your own SQL server name
5. Now you can run the project

### Creating SQL Database
The migrations folder contains all necessary configruation to setup the database, and fill it with seeded data.

### Accessing data
Run the program, and you should be forwarded to the 'API-address'/swagger/index.html. There everything you need to use the API should be documented.


### Contributors:
* [Magnus Uttisrud (@mUttirsurd)](@mUttisrud)
* [Silje Denise Risnes (@silje-denise)](@silje-denise)
