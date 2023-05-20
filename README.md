# BscCSIT-2023-ADO
6th Sem
Add Store procedure 

USE [StudentManagement]

GO
/****** Object:  StoredProcedure [dbo].[sp_AddStudent]    Script Date: 5/20/2023 4:43:05 PM ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[sp_AddStudent]    
(        
    @Name VARCHAR(50),         
    @Section VARCHAR(50)        
)        
as         
Begin         
    Insert into Student (Name,Section)         
    Values (@Name,@Section)         
End
