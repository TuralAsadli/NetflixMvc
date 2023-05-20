# StreamLab

## Project Description:
Webflix is a web-based streaming platform that allows users to watch movies and TV shows online. It provides an extensive collection of content across various genres and supports multiple user profiles.

## Installation Instructions:
1. Clone the repository: `git clone https://github.com/TuralAsadli/NetflixMvc.git`
2. Change database connection string in "appsettings.json"
3. Write in terminal Update-Database to create a database
4. Start the development server: `dotnet run`
5. Open your web browser and visit: `http://localhost:3000`

## Main Pages
1. Home
2. Movies
3. TvShows
4. Register
5. Categories
6. Contact Us
7. Log in
8. Movie Playlist
9. TvShow Playlist
10. Buy Subscribe
11. Search
12. Admin Panel


## Usage Examples:
1. Visit the homepage to browse the available content.
2. Click on a movie or TV show to view its details and watch it.
3. Use the search functionality to find specific content.
4. if you are an admin, you can go to the admin panel and add movies or TV shows
5. Create a user profile to personalize your experience and access your watchlist.
6. Add Some Tvshow or Movie to you wachlist.
7. if you have a complaint about the site, you can write to support in the contact us section


## Features:
- Extensive library of movies and TV shows across various genres.
- User authentication and profile management.
- Search functionality to find specific content.
- Watchlist feature to save content for later viewing.
- Responsive design for optimal viewing experience on different devices.
- Recommendation system based on user preferences and viewing history.
- Integration with external APIs for fetching movie and TV show data (OMDb API).
- Global Exception Handler - if there is an unexpected error in the program, it will automatically show an error 404
- Subscribe system with payment (Stripe)

## Architecture and Patterns:
StreamLab follows a client-server architecture, with the following components:

1. MVC:
    #### MVC stands for Model-View-Controller. It is a software architectural pattern commonly used in designing and developing web applications.
    - In MVC, the "Model" represents the data and business logic of the application. It handles data storage, retrieval, and manipulation.
    - The "View" is responsible for displaying the user interface, presenting the data to the users in a visually appealing way. 
    - The "Controller" acts as an intermediary between the Model and the View. It receives user input, processes it, and updates the Model or the View accordingly.

2. N-Tier:
    #### Application consists of 4 layers
   1. **Interfaces** (Class library, entities's interfaces);
   2. **DAL** (Class library and Context);
   3. **BL** (Class library, Business logic, references the two projects above 1 and 2);
   4. **Web** (ASP.NET MVC application, Presentation Layer, references two projects 1 and 3);

3. Database:
   - Stores movie and TV show data, user information, and user preferences.
   - Can be implemented using relational databases like MsSql, MySQL or PostgreSQL.
   - Ensures data consistency, integrity, and scalability.
   <div class="row" style="display: flex;">
    <div style="margin: 20px;">
        <img src="userDbDisign.png" alt="Image Description" width="500px" height="300px" />
    </div>
    <div style="margin: 20px;">
        <img src="MovieDbDesign.png" alt="Image Description" width="500px" height="300px" />
    </div>
   </div>

4. Generic Repository:
    - **CRUD Operations**: The generic repository supports Create, Read, Update, and Delete operations for entities.
    - **Flexible Entity Types**: You can use the generic repository with various entity types by providing the appropriate type parameter.
    - **Data Source Agnostic**: The repository is designed to work with different data sources, such as databases, file systems, or external APIs.

## Contributing:
Contributions to Webflix are welcome! If you'd like to contribute, please follow these steps:
1. Fork the repository on GitHub.
2. Create a new branch with a descriptive name: `git checkout -b my-feature`
3. Make your changes and test thoroughly.
4. Commit your changes: `git commit -am 'Add new feature'`
5. Push the branch to your forked repository: `git push origin my-feature`
6. Open a pull request on the original repository.



## Contact Information:
For any inquiries or support, please contact Tural Asadli at tural.asadli2003@gmail.com.
