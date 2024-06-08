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
