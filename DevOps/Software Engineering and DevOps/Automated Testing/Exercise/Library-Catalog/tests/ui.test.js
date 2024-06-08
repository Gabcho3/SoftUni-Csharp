import { test, expect } from "@playwright/test";

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
  await page.fill("#email", "peter@abv.bg");
  await page.fill("#password", "123456");
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
  await page.fill("#email", "peter@abv.bg");
  await page.fill("#password", "123456");
  await page.click('input[type="submit"]');

  //Click on "Add Book"
  await page.click('a[href="/create"]')
  
  //Submit "Add Book" form
  await page.fill("#title", "My Book");
  await page.fill("#description", "Some descrription");
  await page.fill("#image", "Some image link");
  await page.selectOption("#type", "Mistery");
  await page.click('input[type="submit"]')

  //Verify book is added
  await page.waitForSelector("#dashboard-page");
  const bookListTitles = await page.$$eval("li.otherBooks > h3", (booksTitles) => 
    booksTitles.map((bookTitle) => bookTitle.textContent)
  );
  expect(bookListTitles).toContain("My Book");
})
