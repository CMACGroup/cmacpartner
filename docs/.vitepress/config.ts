import { defineConfig } from "vitepress";

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "CMAC Partners",
  description:
    "Documentation to support partners of CMAC implement compliant APIs to enable the booking of transport",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: "Home", link: "/" },
      { text: "Test", link: "/pages/test" },
      { text: "Submit Approval", link: "/pages/submitapproval" },
    ],

    sidebar: [
      {
        text: "Authentication",
        link: "/pages/auth",
      },
      {
        text: "Requests",
        items: [
          { text: "Quote", link: "/pages/requests#quote" },
          { text: "Book", link: "/pages/requests#book" },
          { text: "Update", link: "/pages/requests#update" },
          { text: "Cancel", link: "/pages/requests#cancel" },
        ],
      },
      {
        text: "Testing",
        link: "/pages/test",
      },
    ],

    socialLinks: [
      { icon: "github", link: "https://github.com/CMACGroup/cmacpartner" },
      { icon: "twitter", link: "https://twitter.com/CMACgroupuk" },
      {
        icon: "linkedin",
        link: "https://www.linkedin.com/company/cmac-group-uk/",
      },
      { icon: "facebook", link: "https://www.facebook.com/CMACGroup" },
    ],
  },
});