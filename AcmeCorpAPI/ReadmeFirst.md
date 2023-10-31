
AcmeCorpAPI.


Separate folders and files for transparency. The project follows the SOLID and DDD princples.
SQL database is used. Connection String is stored in appsettings.json files.


API Authentication & Authorization is implemented.

JWT Token are used for Bearer Auth.

We assume that there one user, having Admin role, registered in the system.

username: admin
password: 1
role: Admin

Customer Module is authorized for Admin only. To access the API of customers, User needs to login by providing 3 fields in JSON format, in POSTMAN POST request.
//recommended to test on POSTMAN

JWT Token is generated. Copy the provided token in response.

Paste it to the any api calling method of Customer. For example: ../api/customers

Insert the Bearer Token in the request, Customer details will be fetched.

When testing in POSTMAN, do insert the Bearer Token in "Authorizations" section before sending any request.

To fetch Customer by ID, just simply provide the ID like this: ../api/customers/1


Customer and Order functionality has two separate controllers for better understanding.

Customer:
# User can fetch all the customers and their contact information
# User can fetch the customer and it's contact information details by CustomerID as well.
# User can update the customer and it's contact information details by CustomerID.
# User can delete the customer and it's contact information.

Order:
# User can fetch the details of orders.
# User can fetch the order and it's detail by OrderID.