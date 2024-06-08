import { test, expect } from "@playwright/test";

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
