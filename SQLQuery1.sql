ALTER TABLE [dbo].[Products] 
ADD Constraint df_Image1
   DEFAULT 'https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwjc_NiPz8bkAhWE66QKHZ4NCakQjRx6BAgBEAQ&url=https%3A%2F%2Fthenounproject.com%2Fterm%2Fno-image%2F25683%2F&psig=AOvVaw3a-rpp7vt9-zGx6EHKxEOF&ust=1568217374549448'
   FOR ImageURL;

