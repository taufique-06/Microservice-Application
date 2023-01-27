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

1. Create a docker file - https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows. In my opinion, if you didnt enable docker when creating your application, you can do that by right clicking your project -> Add -> Docker Suport (Visual Studio 2022)
2. Build a docker image - [docker build -t taufique06/platfromservice .] -this how you should name an image. So after -t, type your dockerHub username and then your service name. 
3. To run up our image as a container docker run -p 8088:80 -d taufique06/platfromservice

# Few Docker Commands
1. docker ps will show you all the running container
2. To stop a container docker stop <containerId>
3. To restart a container docker start <containerId>
4. To push your image into Docker hub - docker push <imageName>
 
# Kubernetes / K8S
  In a nutshell, Kubernetes helps us to make sure that our containers are running continuously and even if they crash that thet get restarted or to scale them out. Docker compose can be used as an alternative of kubernetes but that's only for devlopment purpose. In terms of production evn, kubernetes is the way to go. 
  # Kubernetes Architecture
  ![tt](https://user-images.githubusercontent.com/85470428/215165241-11c65b99-3f70-46fe-8084-1ab267de5cce.png)
  1. Cluster has two types: Single Cluster which is in our case docker desktop and multi-cluster. Also we dont need to setup a cluster or Node as we are running kubernetes
  2. Inside the Node, we have Pod. A pod basically runs a container. It is used to host and run containers. A single pod can run multiple containers
  3. Node Port is something that allows to test whether the kubernetes working or not. It is only for development purposes. We dont use it in prod env. 
  4. A pod can communicate with another pod by using Cluster IP
  
# Deploy the Platform Service in Kubernetes

 1. For that a folder callled K8S files is created. Inside that folder we created a .yaml file
 2. To deploy our yaml file which is called platform-deployment.yaml - kubectl apply -f <.yaml file name>
 3. Other commands line:
  3.1: kubectl get deployments 
  3.2: kubectl get pods - to run our service
 
 4. At this stage we have our service up and running but we have no way of accessing it. So creating a node port will give us the access. 
 5. we created a file called platform-nodeport-srv.yaml which will create the node port for us. kubectl apply -f <.yaml file name> will create our node port service.
 6. To see that it is running, kubectl get services
