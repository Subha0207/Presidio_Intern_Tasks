
# GitHub to GitLab Repository Migration

This guide will walk you through the process of migrating a repository from GitHub to GitLab.

## 1. Export the Repository from GitHub

First, clone the GitHub repository using the `--mirror` flag to ensure all branches and tags are copied.

```bash
git clone --mirror https://github.com/username/repository.git
```

Replace `username` with your GitHub username and `repository` with your repository name.

Navigate to the cloned repository:

```bash
cd repository.git
```

## 2. Create a New Repository in GitLab

Log in to GitLab and create a new project (repository). **Do not initialize** the repository with a README or any other files.

## 3. Push the Repository to GitLab

Add the GitLab remote to your local repository:

```bash
git remote add gitlab https://gitlab.com/username/repository.git
```

Replace `username` with your GitLab username and `repository` with your repository name.

Push all branches and tags to GitLab:

```bash
git push --mirror gitlab
```

## 4. Verify the Migration

Visit your GitLab repository to ensure that all branches, tags, and commit history have been correctly transferred.

## 5. Update Remote URLs (Optional)

If you intend to continue working with the repository on GitLab, update the remote URL:

```bash
git remote set-url origin https://gitlab.com/username/repository.git
```
