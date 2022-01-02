# Monochrome Project

## Dev Tools

There are some git tools that can make your workflow a little bit more automated and easier. If you're not comfortable with the CLI (command line), you can give these a try:

- Github Desktop
- Git GUI (comes packaged with Git on install)
- Git Kraken or Git Tower

These tools allow you to work with git without using the CLI.

## Dev Workflow

Git is a very hands-on tool so you'll have to manually execute every task. Use feature branches to submit code! Never push code to `master/main`. Some other helpful tips:

* Aim for many small updates, rather than fewer, but huge updates. 
* The more code, the longer it takes your teammates to review it.

If you're using a git desktop tool (such as Git GUI, Github Desktop, Git Tower, etc), you'll have one-click buttons on the top tool bar for the most common tasks. So you won't need to worry about using the CLI too much. 

Below is some guidance for using the CLI.

> NOTE: The terms 'CLI' and 'terminal' refer to the same thing: the command line prompt that you use to type commands into the computer.

**How to download updates**

* Navigate to the project folder root
* Make sure you're on the `main` branch
* `git pull origin main`

**How to upload updates**

* Navigate to the project folder root
* Make sure you're on the relevant branch that you want to upload
* `git push origin YOUR_BRANCH_NAME`

**How to create feature branches**

Even if you use a desktop tool, you'll still need to use the CLI to create new branches. However, if the branch already exists, you can monitor it from your preferred git desktop tool.

Before you create a branch, make sure you first update the `main` branch! You should also make sure there are no outstanding changes.

* Navigate to the project folder using your git desktop tool or file explorer.
* Right click the root folder and select the option for opening it in the terminal.
* `git pull origin main`  (to update your project first)
* `git checkout -b feature/myBranchName`
* Start coding!

Once you're done coding, save your changes and push your branch to this repo. Next, you can make a pull request (PR) so others can review it:

* Find your branch in the drop down menu.
* Click the "Create Pull Request" button 

## Collaboration

* [Discord](https://discord.gg/GHtTV2B7)
* [Project Board](https://trello.com/b/03rH8V64/project-1)

Every project from Hobby Huddle is open to all who want to join. The only rule is that you must see the project to the finish line if you decide to participate. 

Everything you need to know about a given project can be found on the project board.

