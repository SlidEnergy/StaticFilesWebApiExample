# StaticFilesWebApiExample

Steps:
1. Call SaveAvatar method of UserController. File will be saved in wwwroot and fileName, will be saved in the UserModel.
2. Call GetUser method of UserController. This method create token for file.
3. Tokens of files will be cleared periodically by background worker.
