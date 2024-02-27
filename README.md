# Customer Phone System API

### Back End Technology: .NET 8 (API)

This API projects consists of few functionalities below:

1. Get All Phone Numbers of All Customers
2. Get All Phone Numbers of Specific Customer
3. Add New Customer And/Or Add New Phone Number
4. Delete Phone Number
5. Activate Or Deactivate Phone Number

### HTTP Method Summary

|HTTP Method|URL|Description|
|---|---|---|
|`GET`|http://localhost:8000/api/Cust/GetAllCustPhone | Get All Phone Numbers of All Customers |
|`GET`|http://localhost:8000/api/Cust/GetCustPhoneByCustId?custId={custId} | Get All Phone Numbers of Specific Customer |
|`POST`|http://localhost:8000/api/Cust/AddPhone | Add New Customer And/Or Add New Phone Number |
|`DELETE`|http://localhost:8000/api/Cust/DeletePhone | Delete Phone Number |
|`PUT`|http://localhost:8000/api/Cust/TogglePhoneStatus | Activate Or Deactivate Phone Number |

### Assumptions

This customer phone system assumes there is no Create Customer Module. All new phone numbers will not be expected to bind to existing customer in system.