import { test, expect } from "@playwright/test";

const loginEmail = "peter@abv.bg";
const loginPass = "123456";

//Verify links' visability
test('Verify "All books" link is visible', async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Getting link
  const allBooksLink = await page.$('a[href="/catalog"]');

  //Verify link is visible
  const isVisible = await allBooksLink.isVisible();
  expect(isVisible).toBe(true);
});

test('Verify "Login" link is visible', async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Getting link
  const loginLink = await page.$('a[href="/login"]');

  //Verify link is visible
  const isVisible = await loginLink.isVisible();
  expect(isVisible).toBe(true);
});

test('Verify "Register" link is visible', async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Getting link
  const registerLink = await page.$('a[href="/register"]');

  //Verify link is visible
  const isVisible = await registerLink.isVisible();
  expect(isVisible).toBe(true);
});

//Verify user's login
test("Verify user can login", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/login"]');

  //Submit loging form
  await page.fill("#email", loginEmail);
  await page.fill("#password", loginPass);
  await page.click('input[type="submit"]');

  //Verify there is logout button
  const logoutBtn = await page.$("#logoutBtn");
  const isVisible = await logoutBtn.isVisible();
  expect(isVisible).toBe(true);
});

test("Verify dialog appear after login with empty values", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/login"]');

  //Submit loging form
  await page.fill("#email", "");
  await page.fill("#password", "");
  await page.click('input[type="submit"]');

  //Verify dialog appear
  await page.on("dialog", async (dialog) => {
    expect(dialog.type()).toBe("alert");
    expect(dialog.message()).toBe("All fi")
  });
});

//Verify user's register
test("Verify user can register", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/register"]');

  //Submit register form
  await page.fill("#email", "test@abv.bg");
  await page.fill("#password", "123456");
  await page.fill("#repeat-pass", "123456");
  await page.click('input[type="submit"]');

  //Verify user is registered
  const logoutBtn = await page.$("#logoutBtn");
  const isVisible = await logoutBtn.isVisible();
  expect(isVisible).toBe(true);
});

test("Verify user cannot register if repeated password do not match", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/register"]');

  //Submit register form
  await page.fill("#email", "test@abv.bg");
  await page.fill("#password", "123456");
  await page.fill("#repeat-pass", "123");
  await page.click('input[type="submit"]');

  //Verify dialog appeareance
  await page.on("dialog", async dialog => {
    expect(dialog.type()).toBe("alert");
    expect(dialog.message).toBe("Passwords don't match!")
  })
});

//Verify "Add Book" functionality
test("Verify user can add book", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/login"]');

  //Submit login form
  await page.fill("#email", loginEmail);
  await page.fill("#password", loginPass);
  await page.click('input[type="submit"]');

  //Click on "Add Book"
  await page.click('a[href="/create"]')
  
  //Submit "Add Book" form
  await page.fill("#title", "My Book");
  await page.fill("#description", "Some description");
  await page.fill("#image", "Some image link");
  await page.selectOption("#type", "Mistery");
  await page.click('input[type="submit"]')

  //Verify book is added
  await page.waitForSelector("#dashboard-page");
  const bookListTitles = await page.$$eval("li.otherBooks > h3", (booksTitles) => 
    booksTitles.map((bookTitle) => bookTitle.textContent)
  );
  expect(bookListTitles).toContain("My Book");
});

test("Verify user cannot add book with empty values", async ({ page }) => {
  await page.goto("http://localhost:3000");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/login"]');

  //Submit login form
  await page.fill("#email", loginEmail);
  await page.fill("#password", loginPass);
  await page.click('input[type="submit"]');

  //Click on "Add Book"
  await page.click('a[href="/create"]')
  
  //Submit "Add Book" form
  await page.fill("#title", "");
  await page.fill("#description", "");
  await page.fill("#image", "");
  await page.click('input[type="submit"]')

  //Verify dialog appearance
  page.on("dialog", async (dialog) => {
    expect(dialog.type()).toBe("alert");
    expect(dialog.message()).toBe("All fields are required!")
  });
});

//Verify "All Books" functionality
test("Verify that all books are displayed", async ({page}) => {
  await page.goto("http://localhost:3000");
  await page.waitForSelector("nav.navbar");

  //Click "All Books"
  await page.click('a[href="/catalog"]');

  //Get All Books
  const books = await page.$$("li.otherBooks");
  expect(books.length).toBeGreaterThan(0);
});

//Verify "Details" functionality
test("Verify that logged-in user sees details button and button works correctly", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on login
  await page.click('a[href="/login"]');

  //Login
  await page.fill("#email", loginEmail);
  await page.fill("#password", loginPass);
  await page.click('input[type="submit"]');

  //Verify button is visible
  await page.waitForSelector("#dashboard-page");
  const detailsBtn = await page.$("li.otherBooks a.button");
  expect(await detailsBtn.isVisible()).toBe(true);

  //Verify user can click on button
  await page.click(".otherBooks a.button");
  await page.waitForSelector("#details-page");

  const title = await page.$(".book-information > h3");
  expect(await title.textContent()).toBe("My Book");
});

test("Verify that guest user sees details button and button works correctly", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on "All Books"
  await page.click('a[href="/catalog"]');

  //Verify button is visible
  const detailsBtn = await page.$("li.otherBooks a.button");
  expect(await detailsBtn.isVisible()).toBe(true);

  //Verify user can click on button
  await page.click(".otherBooks a.button");
  await page.waitForSelector("#details-page");

  const title = await page.$(".book-information > h3");
  expect(await title.textContent()).toBe("My Book");
});

test("Verify that All book info is displayed correctly", async ({ page }) => {
  await page.goto("http://localhost:3000/");
  await page.waitForSelector("nav.navbar");

  //Click on "All Books"
  await page.click('a[href="/catalog"]');

  //Click on "Details"
  await page.click(".otherBooks a.button");

  //Getting book info from test "Verify user can add book" (col 122)
  //Verify that all info is displayed correctly
  const title = await page.$(".book-information > h3");
  expect(await title.textContent()).toBe("My Book");

  const description = await page.$(".book-description p");
  expect(await description.textContent()).toBe("Some description");

  const type = await page.$(".book-information p.type");
  expect(await type.textContent()).toContain("Mistery");
});