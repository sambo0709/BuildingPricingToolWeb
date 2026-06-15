# Building Pricing Tool Web

## Overview

Building Pricing Tool Web is an ASP.NET Core Razor Pages web application for calculating building estimates based on user-entered dimensions and features.

The app allows users to enter building details such as width, length, wall height, roof pitch, number of doors, and number of windows. It then calculates floor area, wall area, roof area, material cost, labor cost, and total estimated cost.

The project also exports the building data to a CSV file that can be used by a Fusion 360 Python script to generate a simple 3D building model.

## Features

* Web-based building estimate form
* Calculates floor area
* Calculates wall area
* Calculates roof area using roof pitch
* Calculates material cost
* Calculates labor cost
* Calculates total estimated cost
* Saves building data to a CSV file for Fusion 360
* Styled with custom CSS
* Uses semantic HTML structure

## Technologies Used

* C#
* ASP.NET Core
* Razor Pages
* HTML
* CSS
* .NET
* Object-Oriented Programming
* File input/output
* CSV export
* Fusion 360 scripting workflow

## How It Works

The user enters building information into the web form.

Example inputs:

```text
Width: 40
Length: 60
Wall Height: 14
Roof Pitch: 4
Doors: 1
Windows: 4
```

The app calculates:

```text
Floor Area
Wall Area
Roof Area
Material Cost
Labor Cost
Total Cost
```

After the estimate is calculated, the app writes the building data to:

```text
fusion_building_data.csv
```

That CSV file can be read by a Fusion 360 Python script to create a 3D building model.

## Project Structure

```text
Models/
```

Contains the C# classes used by the app.

```text
Models/Building.cs
```

Stores building dimensions and contains the area calculation methods.

```text
Models/Estimate.cs
```

Stores the final estimate results displayed on the page.

```text
Pages/Index.cshtml
```

The main web page users interact with. It contains the building estimate form and displays the results.

```text
Pages/Index.cshtml.cs
```

The C# code-behind file for the homepage. It receives form input, creates a Building object, calculates the estimate, and writes the Fusion CSV file.

```text
wwwroot/css/site.css
```

Custom CSS for styling the web page.

## Running the Project

To run the project locally, open the project folder in a terminal and use:

```bash
dotnet run
```

Then open the local URL shown in the terminal, such as:

```text
http://localhost:5222
```

## Fusion 360 Workflow

This project is designed to connect a C# web app with a Fusion 360 automation script.

The workflow is:

```text
Web form → C# calculations → CSV file → Fusion 360 Python script → 3D building model
```

This shows how software development can be connected with CAD automation and 3D visualization.

## Skills Demonstrated

* ASP.NET Core web development
* Razor Pages
* C# object-oriented programming
* Form handling
* Model classes
* Basic cost estimation logic
* Semantic HTML
* CSS styling
* File writing with C#
* CSV data export
* Fusion 360 automation workflow

## Future Improvements

* Add more detailed material pricing
* Add customer name and project name fields
* Add downloadable estimate reports
* Add validation for form inputs
* Improve the visual design of the web app
* Add rooms and interior walls to the Fusion 360 model
* Add colors and materials to the 3D building
* Export the generated 3D model as an STL file
* Add a direct download option for generated files

## Author

Samuel Boye
