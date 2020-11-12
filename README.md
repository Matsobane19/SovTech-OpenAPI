# SovTech-OpenAPI

project url : https://localhost:44381/swagger/index.html

The OpenApi is configured using swagger

The project consist of three differenct Controllers or Api which is Chuck, Swapi and Search

The First Chuck Api

Get all the categories from the https://api.chucknorris.io/jokes/categories Using HTTpClient

The Swapi Api

Get all the categories from the https://swapi.dev/api/people/ using HttpClient

The Search Api

Get search the results from both Chuck and Swapi Api and return the results from one API that have results.

I split the results based on the response results

If the response results return  @"{"results":[]}") which is null Icheck the length which must be greater that 6



