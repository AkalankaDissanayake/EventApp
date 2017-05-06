# EventApp
Project Configuration--
		1.Please download the project using folowing link
			https://github.com/AkalankaDissanayake/EventApp
		2.Change connection string
			*To test both mvc project and unit test project have to 
			change both project connection strings
		3.Run initial data script 
			*you can find that file inside App.Data project folder
			or check this link 
			https://github.com/AkalankaDissanayake/EventApp/blob/master/App/App.Data/IntDB.sql
		4.Use local iis(api url hardcoded-- have to change that later)
		

Project Artechture
		--App.Data    -- Database acces for primary db operations
		--App.Logic   -- Business logic layer
		--App.Utility -- Sever side common functionalities
		--App.Test    -- Unit testing
		--App.UI      -- Grapical reprecentation
		
		Error Handling-- Db level each esq queary contain try catch block
						 once any arror occered error will be logged to
						 Error table
						 
						 Server side by test file using log4net
