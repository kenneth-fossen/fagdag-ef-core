# Fagdag: .NET EF Core Essentials

It is FagDag and time to learn again.
Here is the rough outline of our content today.

We will mix with theory and then tasks.
There will be intro theory, covering, and then short sessions before a new task.
We want as much hands on practice as much as possible.

The slides used are located in the [docs](docs/slides.md) folder.
See the docs [README.md](docs/README.md) file for more details.

## Overview

## Intro theory

## Task 1: Getting Ready

Ensuring everyone have:

- Installed .NET
- EF Core CLI tools
- Have the code
- Can build and run the project
- Explore the project in the IDE

[Task 1](tasks/1.md)

## Task 2: Simple Model

- Create the model for Events

[Task 2](tasks/2.md)

## Task 3: Migrations & Database Update

- Useful commands
- Create a initial migrations
- Apply the migration to the database
- Change the model

[Task 3](tasks/3.md)

## Task 4: Seeding

- Seed some data
- Install useful library
- Be sure to have applied any migrations before seeding

[Task 4](tasks/4.md)

## Task 5: Querying

- Implementing the service for querying events
- Update the model and seeding the database with new data
- Implement a controller to handle requests for participants

[Task 5](tasks/5.md)

## Task 6: Exploring

- Context Pooling
- Change Database Provider
- Multiple Contexts
- Connection Resilience

[Task 6](tasks/6.md)
