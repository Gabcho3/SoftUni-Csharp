function createBrowserHistory(object, stringArray) {
  let openTabs = object["Open Tabs"];
  let recentlyClosed = object["Recently Closed"];
  let browserLogs = object["Browser Logs"];

  for (let i = 0; i < stringArray.length; i++) {
    const currAction = stringArray[i];
    const [command, site] = currAction.split(" ");

    switch (command) {
      case "Open":
        openTabs.push(site);
        break;

      case "Close":
        while (openTabs.includes(site)) {
          const indexToRemove = openTabs.indexOf(site);
          openTabs.splice(indexToRemove, 1);
        }
        recentlyClosed.push(site);
        break;

      case "Clear":
        openTabs = [];
        recentlyClosed = [];
        browserLogs = [];
        continue;
    }
    browserLogs.push(currAction);
  }
  object["Open Tabs"] = openTabs;
  object["Recently Closed"] = recentlyClosed;
  object["Browser Logs"] = browserLogs;

  const browserInfo = Object.entries(object);
  console.log(browserInfo.shift()[1]);
  for (const [key, value] of browserInfo) {
    console.log(key + ": " + value.join(", "));
  }
}
createBrowserHistory(
  {
    "Browser Name": "Google Chrome",
    "Open Tabs": ["Facebook", "YouTube", "Google Translate"],
    "Recently Closed": ["Yahoo", "Gmail"],
    "Browser Logs": [
      "Open YouTube",
      "Open Yahoo",
      "Open Google Translate",
      "Close Yahoo",
      "Open Gmail",
      "Close Gmail",
      "Open Facebook",
    ],
  },
  ["Close Facebook", "Open StackOverFlow", "Open Google"]
);

createBrowserHistory(
  {
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": [
      "Open Gmail",
      "Close Gmail",
      "Open Dropbox",
      "Open YouTube",
      "Close Dropbox",
    ],
  },
  ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
