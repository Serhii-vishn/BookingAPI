# BookingAPI

This WebAPI provides functionalities for registration, accommodation booking, customer management, and other booking-related operations.

## Description

The project aims to facilitate the management of booking processes for accommodations. It includes features such as user registration, client and accommodation management, booking management, and the ability to add, delete, and view comments about accommodations.

## Features

- **User registration**: Users can register with two roles: Administrator and Customer, or a combination of both.
- **Client Management**: Users with administrator rights can perform CRUD operations on clients, including adding, deleting, editing and viewing client information.
- **Property Management**: Administrator users and clients can view both the list of available accommodation objects and individual ones, administrators can add, delete, edit and view information about accommodation objects.
- **Booking management**: The administrator and the client can perform CRUD operations on bookings, including adding, deleting, editing and viewing booking details.
- **Comment management**: The client can add and view, and administrators can additionally delete comments on bookings.

## How to use

### All operations and checking of the API functionality can be done through the Swagger UI.

### Registration and authentication

1. To use the WebAPI, users must first register.
2. After registration, users will receive authentication credentials (JWT-token).
3. Use the provided credentials to authenticate and access the available endpoints.

### Using endpoints

- **Registration**: Use the `/register` endpoint to register a user.
- **Login**: Use the `/login' endpoint to log in and obtain authentication credentials.
- Client Management: Users with administrator rights can access the `/clients' endpoint to manage clients.
- Housing Management: Administrator users and clients can access the `/accommodations` endpoint to manage accommodation.
- Booking Management: Administrator and client users can access the `/bookings` endpoint to manage bookings.
- Comment Management: The administrator and client users can access the `/booking/{id}/add-comment` endpoint to add comments to the accommodation.

## Technologies Used

- .NET Core
- ASP.NET Core WebAPI
- Entity Framework Core
- SQL Server
- Postman/Swagger

## Contributing

Contributions to the project are welcome. If you have any suggestions, bug reports, or feature requests, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License - [MIT License](LICENSE.txt).
