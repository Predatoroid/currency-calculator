# Currency Calculator API

This is a demo CRUD application providing a REST API for currencies, currency rates & users (authentication & authorization)

## Built With

* [.NET Core](https://github.com/dotnet/core)
* [Entity Framework](https://docs.microsoft.com/en-us/ef/)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019)


## Getting Started

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/Predatoroid/currency-calculator.git
   ```
2. Database: You can leave the settings as is in appsettings.json:
	```javascript
	{
		...
		"ConnectionStrings": {
			"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CurrencyCalculatorDB;Trusted_Connection=True;"
		}
	}
	```
	or if you use a different database in SQL Server, navigate to `CurrencyCalculator.API`  and run the below command in terminal:
	```bash
	dotnet ef database update
	```

3. Navigate to `CurrencyCalculator.API`  in order to run the API:
	```bash
	dotnet run
	```

## Usage
### Swagger

1. Navigate to [Swagger UI](https://localhost:51044/swagger) to see the available endpoints that are described in documentation

2. Send a POST request in `api/auth/login` with the below body (**NOTE**: The Media type has to be **application/json**):
	###### Admin → Access in all actions (currencies, currency rates, users)
	```json
	{
		"username": "admin",
		"password": "123456"
	}
	```
	###### User → Access only in GET requests (currencies, currency rates)
	```json
	{
		"username": "testuser",
		"password": "123456"
	}
	```
3. From the response of the above request, you will receive a token:
	```javascript
	{
		...
		"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjhlMGQzODY0LWRhMmEtNGM2NS04NDMzLTJiYjBjYzExZDcyNCIsInJvbGUiOiJhZG1pbiIsIm5iZiI6MTYyMTMyNzk1MiwiZXhwIjoxNjIxMzU2NzUyLCJpYXQiOjE2MjEzMjc5NTJ9.NnJMUbPA27L6ay_QISAcuJm1Hm1-UJvzCGF4xMe7glQ",
		...
	}
	```
4. Click on "Authorize" button and copy/paste the token with the value:
``
Bearer {token}
``

5. Now as an authorized user, you can send any request that you want

### Postman
1. Navigate to ``Postman configuration``
2. Import the environment & collection files in Postman
3. Test the API

## Roadmap

See the [open issues](https://github.com/Predatoroid/currency-calculator/issues) for a list of proposed features (and known issues).


## Contributing

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Fotis Dimitrakopoulos - f.p.dimitrakopoulos@gmail.com

Project Link: [https://github.com/Predatoroid/currency-calculator](https://github.com/Predatoroid/currency-calculator)
