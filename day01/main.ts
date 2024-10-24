import { map, reduce, split } from "lodash";
import { readInputLine } from "../utils/file-utils";

const input = readInputLine(__dirname, "input.txt");

const parts = split(input, "");

const result = reduce(
  parts,
  (acc, curr) => {
    if (curr === "(") {
      return acc + 1;
    } else if (curr === ")") {
      return acc - 1;
    }
    return acc;
  },
  0
);

console.log(result);
