import * as fs from "fs";
import * as path from "path";

export function readInputLines(dir: string, file: string) {
  const filePath = path.join(dir, file);
  return fs.readFileSync(filePath, "utf-8").split("\n");
}

export function readInputLine(dir: string, file: string) {
  const filePath = path.join(dir, file);
  return fs.readFileSync(filePath, "utf-8");
}
