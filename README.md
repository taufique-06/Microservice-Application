# Microservice-Application

# Creating Platfrom Service

Note: The differences between asynchronous and synchronous include: Async is multi-thread, which means operations or programs can run in parallel. Sync is single-thread, so only one operation or program will run at a time. Async is non-blocking, which means it will send multiple requests to a server. Also, for In-Memory database, migration is not required!

![Platform Service Architecture](https://user-images.githubusercontent.com/85470428/204005407-45ac5476-31f6-42c7-8825-10268dc4f056.PNG)

1. Started with creating Models and then add the DbContext (At the begining, In-Memory Database is used, just to get going)
2. Created Service class for Platform and formed a class called SeedData for having some Mock data
3. DTO (Data Transfer Object) - DTO are basically external representations of our internal models. Why should we do that? Well, We dont wanna expose our internal models to external consumers. The reason is : When you expose your internal models to external consumers be an api, for instance, straight away you are creating a contact with them and if you wanna start changing your internal models which is entirely possible. However, you may break the contact with your consumersand you are basically tying your internal implementation to an external contact which you dont wanna do. 
