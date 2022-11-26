# Microservice-Application

# Creating Platfrom Service

Note: The differences between asynchronous and synchronous include: Async is multi-thread, which means operations or programs can run in parallel. Sync is single-thread, so only one operation or program will run at a time. Async is non-blocking, which means it will send multiple requests to a server. Also, for In-Memory database, migration is not required!

![Platform Service Architecture](https://user-images.githubusercontent.com/85470428/204005407-45ac5476-31f6-42c7-8825-10268dc4f056.PNG)

1. Started with creating Models and then add the DbContext (At the begining, In-Memory Database is used, just to get going)
2. Created Service class for Platform and formed a class called SeedData for having some Mock data
3. DTO (Data Transfer Object) - DTO are basically external representations of our internal models. Why should we do that? Well, We dont wanna expose our internal models to external consumers. The reason is : When you expose your internal models to external consumers be an api, for instance, straight away you are creating a contact with them and if you wanna start changing your internal models which is entirely possible. However, you may break the contact with your consumersand you are basically tying your internal implementation to an external contact which you dont wanna do. 


# Docker and Kubernetes

Docker: It is a containerization platform, meaning that it enables you to package your application into images and run them as "containers" on any platform that can run docker. In simple term, When you develop an application on your machine and it works perfectly fine on your machine. However, when you share yout files with others, it doesnt work on their machine. This problem can be solved by docker which will allow you to package your application into image. Once you have that image, you can take that image and place onto anything else that is running docker and run that image up as a container.

Next Step:

1. Create a docker file - https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows
