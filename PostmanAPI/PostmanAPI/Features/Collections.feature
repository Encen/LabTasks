Feature: Work with collections
	In order to work easily with collections
	As a user
	I want to make all possible operations with collections 

Scenario: 01 Get the list of existing collections 
	Given I have a collection with name TEST 
	When I send GET request to postman collections api
	Then I get the list of my collections

	Scenario: 02 Create new collection 
	
	When I send POST request to postman collections api
	Then New collection will be created

	Scenario: 03 Update existing collection
	Given I have a collection with name TEST
	When I send PUT request to postman collections api with new Name
	Then The collection will be renamed

	Scenario: 04 Get the list of existing collections 
	Given I have a collection
	When I send DELETE request to postman collections api
	Then The collection will be deleted 
