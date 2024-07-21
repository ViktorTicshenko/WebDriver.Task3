# Automation Task 3 using Selenium WebDriver, NUnit, and Page Object Pattern

## Description
This repository contains a task automation script using Selenium WebDriver, NUnit, and the Page Object Model (POM) concept. The script automates the creation of a new paste on Pastebin (or a similar service) with specified attributes and verifies the correctness of the operation.

## Requirements
- .NET Framework or .NET Core
- NUnit framework
- Selenium WebDriver for .NET
- WebDriver-compatible browser (e.g., Chrome, Firefox, Edge)

## The script performs the following actions:

1. Opens the [Google Cloud Pricing Calculator](https://cloud.google.com/).
2. Clicks on the "Add to estimate" button.
3. Selects "Compute Engine".
4. Fills out the form with specific data.
5. Clicks "Share" to see the total estimated cost.
6. Clicks "Open estimate summary" to view the Cost Estimate Summary in a new tab.
7. Verifies that the 'Cost Estimate Summary' matches the filled values.