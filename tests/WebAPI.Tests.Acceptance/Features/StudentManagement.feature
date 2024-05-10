Feature: StudentManagement

Create, Read, Update, Delete Student

Background: system error codes are following
          | Code | Description                                                |
          | 500  | Internal Server Error                                      |

Scenario: User creates, reads, updates and deletes a student
	Given platform has "0" students
	When user creates a student with following data by sending 'Create Student Command' through API
		| FirstName | LastName | Email        | BirthDate  | GitHubUsername |
		| John      | Doe      | john@doe.com | 2004-01-01 | john-doe       |
	Then user requests to get all the students and it must return "1" student with following data
		| FirstName | LastName | Email        | BirthDate  | GitHubUsername |
		| John      | Doe      | john@doe.com | 2004-01-01 | john-doe       |
	When user creates another student with following data by sending 'Create Student Command' through API
		| FirstName | LastName | Email          | BirthDate  | GitHubUsername |
		| John      | Doe      | john@gmail.com | 2004-01-01 | john-doe       |
	Then user must get status code "500"
	When user updates student by email "john@doe.com" with following data
		| FirstName | LastName | Email            | BirthDate  | GitHubUsername |
		| Jane      | William  | jane@william.com | 2000-01-01 | jane-will      |
	Then user requests to get all the students and it must return "1" student
		| FirstName | LastName | Email            | BirthDate  | GitHubUsername |
		| Jane      | William  | jane@william.com | 2000-01-01 | jane-will      |
	When user deletes student by Email of "jane@william.com"
	Then user requests to get all students and it must return "0" students