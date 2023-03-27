import express from "express";
import quoteController from "./controllers/quote";
const router = express.Router();

router.post("/posts", quoteController.getPosts);

export = router;
