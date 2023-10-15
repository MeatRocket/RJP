
# RJP

A simple API with UI to create a customer account and to view customers' information including transactions




## Intro
The project utilized 3 main projects:
- RJP UI
- RJP API
- RJP Unit Test

Their names are self explanatory.
## How to run this project

To run it is super simple, you need to run the RJP UI and the RJP API projects. In order for the UI to communicate with the API, since it is only utilizing a mock database statically present inside the RJP API project.

You can 2 instances of visual studio to run these porjects or 2 instances of your CMD with the command 

```sh
dotnet run
```
## API Methods

#### Get customer infomation

```http
  GET {the name of your local api domain}/api/Customer/GetCustomerInformation
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| 'CustomerId' | `int` | **Required** Customer Id |


#### Create customer account

```http
  POST {the name of your local api domain}/api/Account/CreateAccount
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `CustomerId`      | `int` | **Required**. Customer Id|
| `InitialCredit`      | `double` | **Required**. Initial account credit |

Creates an account for the user with the balance provided

