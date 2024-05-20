# Water Customer App Test Suite

## Overview

This repository contains the test plan and automated test suites for the Water Customer App. It includes both API and UI level tests to ensure that all functionalities meet the expected outcomes.

## Prerequisites

Before running the tests, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or higher)
- [Playwright](https://playwright.dev/) for running the UI tests
- A local or remote instance of the Klir_interview project running on `http://localhost:3000` for the frontend and `http://localhost:3001` for the backend.

## Project Structure

- `/test-plan` - Contains the test plan and manual test results.

  - `test_plan.md` - Markdown file with the test plan.
  - `/results/test_results.md` - Markdown file with results and screenshots.

- `/api-tests/WaterCustomerAppTest` - Contains all the API level tests written using NUnit and Playwright.

  - `Features` - Directory containing the feature files for API tests.
  - `StepDefinitions` - Directory containing the step definitions for API tests.

- `/ui-tests/WaterCustomerAppUITests` - Contains all the UI tests for the frontend using Playwright and NUnit.
  - `Features` - Directory containing the feature files for UI tests.
  - `StepDefinitions` - Directory containing the step definitions for UI tests.

## Setting Up the Test Environment

**Clone the Repository:**

```bash
git clone https://github.com/yourusername/water-customer-app-test.git
cd water-customer-app-test
```

## Running the Automated Tests

### API Tests

1. **Navigate to the API tests directory:**

   ```bash
   cd api-tests/WaterCustomerAppTest
   ```

2. **Install the necessary dependencies:**

   ```bash
   dotnet restore

   ```

3. **Run the API tests::**

   ```bash
   dotnet test

   ```

### UI Tests

1. **Navigate to the API tests directory:**

   ```bash
   cd ui-tests/WaterCustomerAppUITests
   ```

2. **Install the necessary dependencies:**

   ```bash
   dotnet restore

   ```

3. **Run the API tests::**

   ```bash
   dotnet test

   ```

## Test Results

The test results, including screenshots for failed tests, will be available in the `/results` directory.

## Observation

**Important:** Tasks 3 and 4 of Klir's Test Automation Challenge involve automating tests for non-compliant scenarios. As these scenarios are expected to highlight issues within the application, most of the tests in these tasks are designed to fail. This is intentional and demonstrates the application's handling of incorrect or unexpected inputs and conditions.