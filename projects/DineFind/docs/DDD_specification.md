# DineFind: Domain-Driven Design (DDD) Specification

## Introduction

DineFind is a web application designed to help users discover restaurants, offering recommendations based on location, preferences, and reviews. This Domain-Driven Design (DDD) specification outlines the core domain, subdomains, entities, value objects, aggregates, and services required to build DineFind using a DDD approach. The project follows an N-Layer architecture with bounded contexts and domain models.

### Strategic Design

**Domain:** Restaurant Discovery and Recommendations  
**Core Subdomains:**
1. **Restaurant Discovery** - Core domain where users can search for restaurants based on preferences, location, and other filters.
2. **User Preferences** - Manage user preferences for restaurants, cuisines, and types of dining.
3. **Reviews and Ratings** - Users can leave feedback and rate restaurants.
4. **Restaurant Management** - Admin domain for restaurant owners to manage restaurant information.

### Ubiquitous Language
Key terms used throughout the application:  
- **Restaurant**: A place where food is served.
- **Cuisine**: Type of food served by a restaurant.
- **User**: Person searching for restaurants or providing reviews.
- **Rating**: Score given by a user to a restaurant.
- **Review**: Written feedback about a restaurant.
- **Location**: The geographical area where the restaurant operates.
- **Recommendation**: Suggested restaurant based on user preferences.

### Bounded Contexts

1. **Restaurant Discovery Context**: Focused on discovering restaurants based on search criteria such as location and cuisine.
    - Entities: Restaurant, Location
    - Value Objects: SearchCriteria, Cuisine, Coordinates
    - Services: SearchService, RestaurantRecommendationService

2. **User Preferences Context**: Handles user-specific information and their food preferences.
    - Entities: User, Preference
    - Value Objects: CuisinePreference, PriceRange
    - Services: UserPreferenceService

3. **Reviews and Ratings Context**: Manages user reviews and ratings for restaurants.
    - Entities: Review, Rating, User, Restaurant
    - Value Objects: RatingScore, ReviewContent
    - Services: ReviewService, RatingService

4. **Restaurant Management Context**: For restaurant owners to manage restaurant details.
    - Entities: RestaurantOwner, Restaurant
    - Value Objects: OpeningHours, Address
    - Services: RestaurantManagementService

### Context Mapping

- **Restaurant Discovery ↔ Reviews and Ratings**: When a user searches for restaurants, the ratings and reviews must be fetched to enhance the search results.
- **User Preferences ↔ Restaurant Discovery**: Recommendations are based on the user’s preferences stored in the User Preferences context.
- **Restaurant Management ↔ Restaurant Discovery**: The data managed by restaurant owners is used for display in the discovery results.

### Anti-Corruption Layer

To prevent the contamination of different subdomains with unnecessary information, mappers and anti-corruption layers are employed. For example, a mapper between **User Preferences** and **Restaurant Discovery** ensures that only the necessary data about a user's preferences is shared.

## Tactical Design

### Entities

1. **Restaurant**: Represents a restaurant.
    - Properties: Name, Address, Cuisine, Rating, Reviews, Coordinates
2. **User**: Represents a user of the platform.
    - Properties: Username, Email, Preferences, Reviews
3. **Review**: Represents a review left by a user.
    - Properties: Content, Rating, Date, UserId, RestaurantId
4. **Preference**: Represents a user's dining preferences.
    - Properties: Cuisine, PriceRange, Distance
5. **RestaurantOwner**: Represents an owner of a restaurant.
    - Properties: Name, Email, Restaurants

### Value Objects

1. **Cuisine**: Represents the type of food a restaurant serves.
    - Properties: Name, Description
2. **SearchCriteria**: Represents the search parameters when looking for a restaurant.
    - Properties: Cuisine, Location, PriceRange
3. **Coordinates**: Represents the geographical coordinates of a restaurant.
    - Properties: Latitude, Longitude
4. **RatingScore**: Represents a numerical rating.
    - Properties: Score (1-5)

### Aggregates

1. **RestaurantAggregate**:  
   - **Root Entity**: Restaurant  
   - Contains: Rating, Reviews, Cuisine, Coordinates  
   - Business Rule: A restaurant's average rating is recalculated each time a new rating is submitted.

2. **UserAggregate**:  
   - **Root Entity**: User  
   - Contains: Preferences, Reviews  
   - Business Rule: Users can only review a restaurant once.

### Services

1. **SearchService**:  
   - Operation: `SearchRestaurants(criteria: SearchCriteria)`  
   - Responsible for performing searches based on user-defined criteria.
  
2. **RestaurantRecommendationService**:  
   - Operation: `RecommendRestaurants(userId: Guid)`  
   - Provides restaurant recommendations based on user preferences.

3. **UserPreferenceService**:  
   - Operation: `GetUserPreferences(userId: Guid)`  
   - Retrieves and updates user preferences.

4. **ReviewService**:  
   - Operation: `SubmitReview(userId: Guid, restaurantId: Guid, content: ReviewContent)`  
   - Manages user-submitted reviews for restaurants.

### Repositories

1. **IRestaurantRepository**:  
   - Method: `GetById(Guid id)`, `Search(SearchCriteria criteria)`  
   - Responsible for retrieving and searching restaurant entities.

2. **IUserRepository**:  
   - Method: `GetById(Guid id)`, `UpdatePreferences(User user)`  
   - Manages user-related data.

3. **IReviewRepository**:  
   - Method: `Submit(Review review)`  
   - Stores and retrieves reviews.

### Business Rules and Invariants

- A user can only submit one review per restaurant.
- The restaurant’s rating is the average of all user ratings.
- Restaurants can only be recommended to users if they match the user’s preferences.

## Folder Structure

```plaintext
DineFind/
│
├── Domain/
│   ├── Entities/
│   │   ├── Restaurant.cs
│   │   ├── User.cs
│   │   ├── Review.cs
│   └── Aggregates/
│   │   ├── RestaurantAggregate.cs
│   │   └── UserAggregate.cs
│   └── ValueObjects/
│       ├── Cuisine.cs
│       ├── Coordinates.cs
│       ├── SearchCriteria.cs
├── Services/
│   ├── SearchService.cs
│   ├── UserPreferenceService.cs
│   ├── ReviewService.cs
│   ├── RestaurantRecommendationService.cs
├── Repositories/
│   ├── IRestaurantRepository.cs
│   ├── IUserRepository.cs
│   ├── IReviewRepository.cs
├── Infrastructure/
│   ├── Persistence/
│   │   ├── RestaurantRepository.cs
│   │   └── UserRepository.cs
├── API/
│   ├── Controllers/
│   │   ├── RestaurantController.cs
│   │   ├── UserController.cs
│   │   └── ReviewController.cs
├── UI/
│   ├── Views/
│   ├── Components/
│   └── Layouts/
```

Since we have a MVC application the previous folder structure have some folder name changes:
- Domain -> Models.
- Services -> Services.
- Repositories -> Repositories.
- Infrastructure -> Infrastructure.
- API -> Controllers.
- UI -> Views.

## Conclusion

The DineFind application will be designed to model the restaurant discovery and recommendation domain, focusing on strategic and tactical patterns from Domain-Driven Design. This specification details the entities, value objects, services, and repositories required to maintain business invariants and properly model the domain.