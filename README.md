# Basic unit testing course for csharp developers

## What is unit testing?
It's the practice of writing code to test your code and then run those tests in an automated fashion. A unit test is a test that exercises individual software components or methods, also known as "unit of work". Unit tests should only test code within the developer's control. 

They **do not test infrastructure concerns**. Infrastructure concerns include interacting with databases, file systems, and network resources.

## Why learn unit testing?

Why write extra code? Why not just run the application and test it like an end user? Thinking like this is the mistake lots of people make. If you’re building a complex application or working on a legacy app, manually testing all the various functions is tedious and takes a significant amount of time.

As your application grows, the cost of manual testing grows exponentially. And you’re never 100% sure if you’ve fully tested all the edge cases. 

The later a bug is caught in the software development lifecycle, the more costly it is to the business. Automated tests help you to catch bugs earlier, right when you’re coding. These tests are repeatable, write them once and run them over and over.

## The benefits of using unit tests are:

- Catch and fix bugs earlier, before releasing your app into production
- Write better code with less bugs
- Produce software with better design, extensible and loosely-coupled
- Help you to think of edge cases that you didn’t realize existed
- Tell if you have broken any functionality as you write new code
- Allow you to refactor your code with confidence
- Act as documentation about what your code does

## The changes we make on a day-to-day basis can have huge impacts. For example:

- Does your switch properly account for a new value you put in?
- Do you know how many times you used that switch?
- Did you properly account for case insensitive string comparisons?
- Are you checking for nulls appropriately?
- Does a throw exception get handled as you expected?