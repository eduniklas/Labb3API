# Labb3API

# About the task:

In this lab, you will test building your first simple Web API. The API you will construct follows a REST architecture and will allow external services and applications to retrieve and modify data in your own application.

# What you need to do:

<aside>
**Application/Database**

The first thing you should create is a very basic application with a database that can handle the following:

- [ ] It should be possible to store individuals with basic information such as names and phone numbers.
- [ ] The system should be able to store an unlimited number of interests they have. Each interest should have a title and a brief description.
- [ ] Each person can be linked to any number of interests.
- [ ] An unlimited number of links (to websites) should be possible to store for each interest for each person. If a person adds a link, it is linked both to that person and to that interest.

**Create a REST API**

The second step you should take is to create a REST API that allows external services to make the following requests to your API and make these changes in your application.

- [ ] Retrieve all individuals in the system.
- [ ] Retrieve all interests linked to a specific individual.
- [ ] Retrieve all links linked to a specific individual.
- [ ] Link an individual to a new interest.
- [ ] Add new links for a specific individual and a specific interest.

---

**Extra Challenge (do if you want)**

- [ ] Allow the API caller to request all interests and all links for an individual directly in a hierarchical JSON file.
- [ ] Provide the API caller with the ability to filter what they receive, like a search. For example, if I send "to" when requesting all individuals, I want those with "to" in the name, such as "Tobias" or "Tomas." You can implement this for all the requests if you wish.
- [ ] Implement pagination of the requests. When I request, for example, individuals, I might get the first 100 individuals and then have to make further requests to get more. Here, it might also be nice if the request determines how many individuals I get in one request, so I can choose to get, say, 10 if that's all I want.

**Test Your API**

The final step is to make requests to your API using the [Postman](https://www.postman.com/) service or Swagger.

- [ ] Make a request for each requirement listed above for the API.
- [ ] In your Git readme file, include all the requests you have made for each requirement related to the API so we can see how you envision the requests should look.
