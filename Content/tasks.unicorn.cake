Sitecore.Tasks.SyncAllUnicornItems = Task("Sync :: Unicorn")
    .Description("Run Unicorn sync process")
    .Does(() =>
    {
        Sitecore.Utils.AssertIfNullOrEmpty(Sitecore.Parameters.ScSiteUrl, "ScSiteUrl", "SC_SITE_URL");
        Sitecore.Utils.AssertIfNullOrEmpty(Sitecore.Parameters.UnicornConfigPath, "UnicornConfigPath", "UNICORN_CONFIG_PATH");

        var _unicornSecret = getUnicornSecret(Sitecore.Parameters.UnicornConfigPath);
        var _scriptsDir = Context.Tools.Resolve("unicorn/*.psm1").GetDirectory().ToString(); // TODO: resolve dir from tools

        runUnicornSync(Sitecore.Parameters.ScSiteUrl, _unicornSecret, _scriptsDir);
    });
 