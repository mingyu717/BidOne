# BidOne

This code includes following two parts:
1. test-form: the angular front-end. The front-end is a simple angular form to submit profile including first name and last name.
2. TestFormService: the azure function back-end. 
	The test form service is a .net core http triggered azure function. The default endpoint is http://localhost:7071/api/SaveFile.
	In the back-end, I have followed the SOLID principle to write clean code. It uses unity for depency injection, nunit and moq for unit testing. 

