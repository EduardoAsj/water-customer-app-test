# Test Plan for Water Customers App

## 1. Welcome Screen

### Test Case 1: Verify Form Elements

- **Description:** Ensure that the Welcome Screen form elements are displayed correctly.
- **Steps:**
  1) Open the Water Customers App.
  2) Verify that the instructions text "Please provide your name:" is visible.
  3) Verify that the text field for entering the user's name is present.
  4) Verify that the Submit button is visible.
- **Expected Result:** All form elements are displayed correctly.

### Test Case 2: Submit Form with Valid Name

- **Description:** Verify the behavior when submitting the form with a valid name.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field.
  3) Click the Submit button.
- **Expected Result:** The Customer List Screen is displayed.

### Test Case 3: Submit Form with Empty Name

- **Description:** Verify the behavior when submitting the form with an empty name.
- **Steps:**
  1) Open the Water Customers App.
  2) Leave the text field empty.
  3) Click the Submit button.
- **Expected Result:** An alert message "Please provide your name" is displayed.

## 2. Customer List Screen

### Test Case 4: Verify Customer List Display

- **Description:** Ensure that the Customer List Screen displays all registered customers with correct details.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) Verify that the Customer List Screen displays a list of all registered customers.
- **Expected Result:** A list of all registered customers is displayed, each showing their Name, # of Employees, and Size.

### Test Case 5: Customer Size Calculation

- **Description:** Verify that the size of each customer is calculated correctly based on the number of employees.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) Click on a customer's name in the list.
- **Expected Result:**
  - Customers with employees <= 2500 are labeled "Small".
  - Customers with employees between 2501 and 5000 are labeled "Medium".
  - Customers with employees > 5000 are labeled "Big".

### Test Case 6: Click on Customer Name

- **Description:** Verify that clicking on a customer's name navigates to the Contacts Detail Screen.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) On the Customer List Screen, click on a customer's name.
- **Expected Result:** The Contacts Detail Screen for the selected customer is displayed.

## 3. Contacts Detail Screen

### Test Case 7: Verify Customer Details Display

- **Description:** Ensure that the Contacts Detail Screen displays the customer's detailed information correctly.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) On the Customer List Screen, click on a customer's name to view their details.
- **Expected Result:** The customer's detailed information (name, # of employees, size, and the contact person's name and email) is displayed correctly.

### Test Case 8: Verify Contact Information Display

- **Description:** Verify that the correct message is displayed when no contact information is available.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) On the Customer List Screen, click on a customer's name to view their details.
- **Expected Result:** If contact information is available, the contact person's name and email are displayed. Otherwise, the message "No contact info available" is displayed.

### Test Case 9: Click on "Back to the list" Button

- **Description:** Verify the behavior when clicking on the "Back to the list" button.
- **Steps:**
  1) Open the Water Customers App.
  2) Enter a valid name in the text field on the Welcome Screen.
  3) Click the Submit button.
  4) On the Customer List Screen, click on a customer's name to view their details.
  5) Click on the "Back to the list" button.
- **Expected Result:** The Customer List Screen is displayed.

## 4. API Tests

### Test Case 10: POST Request with Valid Name

- **Description:** Verify that a valid POST request returns the user's name, the current timestamp, and the list of customers with their details.
- **Steps:**
  1) Open Postman or any API testing tool.
  2) Set the request method to "POST".
  3) Set the URL to "http://localhost:3001/".
  4) In the request body, enter "{"name":"Eduardo Afonso"}".
  5) Send the request.
  6) Verify the response status code is "200 OK".
  7) Verify the response header "Content-Type" is "application/json".
  8) Verify the response body contains:
     - "name": "Eduardo Afonso"
     - A "timestamp" field with the current timestamp.
     - A "customers" array with customer details, including "id", "name", "employees", "contactInfo" (if available), and "size".
- **Expected Result:** The response status code is "200 OK", and the response body contains the correct user name, timestamp, and customer details as specified.

  ### Test Case 11: POST Request with Empty Name

- **Description:** Verify that a POST request with an empty name returns an error.
- **Steps:**
  1) Open Postman or any API testing tool.
  2) Set the request method to "POST".
  3) Set the URL to "http://localhost:3001/".
  4) In the request body, enter "{"name":""}".
  5) Send the request.
  6) Verify the response status code is "400 Bad Request".
  7) Verify the response body contains:
     - "error": "Please provide your name"
- **Expected Result:** The response status code is "400 Bad Request", and the response body contains the error message "Please provide your name".

  ### Test Case 12: POST Request with Blank Request Body

- **Description:** Verify that a POST request with a blank Request Body returns an error.
- **Steps:**
  1) Open Postman or any API testing tool.
  2) Set the request method to "POST".
  3) Set the URL to "http://localhost:3001/".
  4) In the request body, enter "{}".
  5) Send the request.
  6) Verify the response status code is "400 Bad Request".
  7) Verify the response body contains:
     - "error": "Please provide your name"
- **Expected Result:** The response status code is "400 Bad Request", and the response body contains the error message "Please provide your name".

### Test Case 13: POST Request Without Contact Info

- **Description:** Verify that a POST request returns customers without contact information if it's not available in the database.
- **Steps:**
  1) Open Postman or any API testing tool.
  2) Set the request method to "POST".
  3) Set the URL to "http://localhost:3001/".
  4) In the request body, enter {"name":"Eduardo Afonso"}.
  5) Send the request.
  6) Verify the response status code is "200 OK".
  7) Verify the response body contains:
     - "name": "Eduardo Afonso"
     - A "timestamp" field with the current timestamp.
     - A "customers" array with customer details, ensuring customers without contact info do not have the "contactInfo" field.
- **Expected Result:** The response status code is "200 OK", and the response body contains the correct user name, timestamp, and customer details, with the "contactInfo" field omitted for customers without contact information.

### Test Case 14: POST Customer Size Calculation

- **Description:** Verify that a POST request returns customers without contact information if it's not available in the database.
- **Steps:**
  1) Open Postman or any API testing tool.
  2) Set the request method to "POST".
  3) Set the URL to "http://localhost:3001/".
  4) In the request body, enter {"name":"Eduardo Afonso"}.
  5) Send the request.
  6) Verify the response status code is "200 OK".
  7) Verify the response body contains:
     - A "customers" array. For each customer, ensure the "size" field is:
       - "Small" if "employees" is <= 2500.
       - "Medium" if "employees" is > 2500 and <= 5000.
       - "Big" if "employees" is > 5000.
- **Expected Result:** The response status code is "200 OK", and the response body correctly calculates the customer size based on the number of employees.
