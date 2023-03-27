import { Request, Response, NextFunction } from "express";

interface Post {
  userId: Number;
  id: Number;
  title: String;
  body: String;
}

// getting all posts
const getPosts = async (req: Request, res: Response, next: NextFunction) => {
  // get some posts
  let posts: [Post] = result.data;
  return res.status(200).json({
    message: posts,
  });
};

export default { getPosts };
