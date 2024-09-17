/*Given an integer x, return true if x is a 
palindrome
, and false otherwise.

 

Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 */
var isPalindrome = function (x) {
    var t = 0, aux = x;
    while (aux != 0) {
        var c = aux % 10;
        t = t * 10 + c;
        aux = Math.floor(aux / 10);
    }

    return t == x;
};
// console.log(isPalindrome(1234));
// console.log(isPalindrome(121));


/*Write a function argumentsLength that returns the count of arguments passed to it.

Example 1:

Input: args = [5]
Output: 1
Explanation:
argumentsLength(5); // 1

One value was passed to the function so it should return 1.
Example 2:

Input: args = [{}, null, "3"]
Output: 3
Explanation: 
argumentsLength({}, null, "3"); // 3

Three values were passed to the function so it should return 3.*/
function argumentsLength() {
    return arguments.length;
}
console.log(argumentsLength(5));


/*Write a function createHelloWorld. It should return a new function that always returns "Hello World".
 

Example 1:

Input: args = []
Output: "Hello World"
Explanation:
const f = createHelloWorld();
f(); // "Hello World"

The function returned by createHelloWorld should always return "Hello World".
Example 2:

Input: args = [{},null,42]
Output: "Hello World"
Explanation:
const f = createHelloWorld();
f({}, null, 42); // "Hello World"

Any arguments could be passed to the function but it should still always return "Hello World".
 */
var createHelloWorld = function() {
    return function() {
        return "Hello World";
    };
};


/*Given an integer n, return a counter function. This counter function initially returns n and then returns 1 more than the previous value every subsequent time it is called (n, n + 1, n + 2, etc).

 

Example 1:

Input: 
n = 10 
["call","call","call"]
Output: [10,11,12]
Explanation: 
counter() = 10 // The first time counter() is called, it returns n.
counter() = 11 // Returns 1 more than the previous time.
counter() = 12 // Returns 1 more than the previous time.
Example 2:

Input: 
n = -2
["call","call","call","call","call"]
Output: [-2,-1,0,1,2]
Explanation: counter() initially returns -2. Then increases after each sebsequent call.
 * @param {number} n
 * @return {Function} counter
 * const counter = createCounter(10)
 * counter() // 10
 * counter() // 11
 * counter() // 12
 */
var aux = 0;
var createCounter = function (n) {

    return function () {
        return n++;
    };
};
// const counter = createCounter(10);
// console.log(counter());
// console.log(counter());
// console.log(counter());
// console.log(counter());


/*?????????????????*/
/*Given a positive integer millis, write an asynchronous function that sleeps for millis milliseconds. It can resolve any value.
Example 1:

Input: millis = 100
Output: 100
Explanation: It should return a promise that resolves after 100ms.
let t = Date.now();
sleep(100).then(() => {
  console.log(Date.now() - t); // 100
});
Example 2:

Input: millis = 200
Output: 200
Explanation: It should return a promise that resolves after 200ms.
 */
/*?????????????????*/


/*Write a function createCounter. It should accept an initial integer init. It should return an object with three functions.

The three functions are:

increment() increases the current value by 1 and then returns it.
decrement() reduces the current value by 1 and then returns it.
reset() sets the current value to init and then returns it.
 

Example 1:

Input: init = 5, calls = ["increment","reset","decrement"]
Output: [6,5,4]
Explanation:
const counter = createCounter(5);
counter.increment(); // 6
counter.reset(); // 5
counter.decrement(); // 4
Example 2:

Input: init = 0, calls = ["increment","increment","decrement","reset","reset"]
Output: [1,2,1,0,0]
Explanation:
const counter = createCounter(0);
counter.increment(); // 1
counter.increment(); // 2
counter.decrement(); // 1
counter.reset(); // 0
counter.reset(); // 0
 */
var createCounter = function (init) {
    let ct = init;
    return {
        increment: function () {
            ct++;
            return ct;
        },
        decrement: function () {
            ct--;
            return ct;
        },
        reset: function () {
            ct = init;
            return ct;
        }
    }

};
// const counter1 = createCounter(0);
// console.log(counter1.increment());
// console.log(counter1.increment());
// console.log(counter1.decrement());
// console.log(counter1.reset());


/*Write a generator function that returns a generator object which yields the fibonacci sequence.

The fibonacci sequence is defined by the relation Xn = Xn-1 + Xn-2.

The first few numbers of the series are 0, 1, 1, 2, 3, 5, 8, 13.

 

Example 1:

Input: callCount = 5
Output: [0,1,1,2,3]
Explanation:
const gen = fibGenerator();
gen.next().value; // 0
gen.next().value; // 1
gen.next().value; // 1
gen.next().value; // 2
gen.next().value; // 3
Example 2:

Input: callCount = 0
Output: []
Explanation: gen.next() is never called so nothing is outputted
  */
var fibGenerator = function () {
    let a = 0, b = 1;

    return {
        next: function () {
            let current = a;
            let temp = a;
            a = b;
            b = temp + b;
            return {value : current};
        }
    };
};
// const gen = fibGenerator();
// console.log(gen.next().value); 
// console.log(gen.next().value);
// console.log(gen.next().value);
// console.log(gen.next().value); 


/*Given an array arr and a chunk size size, return a chunked array.

A chunked array contains the original elements in arr, but consists of subarrays each of length size. The length of the last subarray may be less than size if arr.length is not evenly divisible by size.

You may assume the array is the output of JSON.parse. In other words, it is valid JSON.

Please solve it without using lodash's _.chunk function.

 

Example 1:

Input: arr = [1,2,3,4,5], size = 1
Output: [[1],[2],[3],[4],[5]]
Explanation: The arr has been split into subarrays each with 1 element.
Example 2:

Input: arr = [1,9,6,3,2], size = 3
Output: [[1,9,6],[3,2]]
Explanation: The arr has been split into subarrays with 3 elements. However, only two elements are left for the 2nd subarray.
Example 3:

Input: arr = [8,5,3,2,6], size = 6
Output: [[8,5,3,2,6]]
Explanation: Size is greater than arr.length thus all elements are in the first subarray.
Example 4:

Input: arr = [], size = 1
Output: []
Explanation: There are no elements to be chunked so an empty array is returned.*/
function chunkArray(arr, size) {
    const chunked = [];
    for (let i = 0; i < arr.length; i += size) {
        const chunk = [];
        for (let j = 0; j < size && i + j < arr.length; j++) {
            chunk.push(arr[i + j]);
        }
        chunked.push(chunk);
    }
    return chunked;
}
console.log(chunkArray([1, 2, 3, 4, 5], 1));
console.log(chunkArray([1, 9, 6, 3, 2], 3));


/*Write a function expect that helps developers test their code. It should take in any value val and return an object with the following two functions.

toBe(val) accepts another value and returns true if the two values === each other. If they are not equal, it should throw an error "Not Equal".
notToBe(val) accepts another value and returns true if the two values !== each other. If they are equal, it should throw an error "Equal".
 

Example 1:

Input: func = () => expect(5).toBe(5)
Output: {"value": true}
Explanation: 5 === 5 so this expression returns true.
Example 2:

Input: func = () => expect(5).toBe(null)
Output: {"error": "Not Equal"}
Explanation: 5 !== null so this expression throw the error "Not Equal".
Example 3:

Input: func = () => expect(5).notToBe(null)
Output: {"value": true}
Explanation: 5 !== null so this expression returns true.*/
var expect = function(val) {
    return {
        toBe: function(expected) {
            if (val === expected) {
                return { value: true };
            } else {
                throw new Error("Not Equal");
            }
        },
        notToBe: function(expected) {
            if (val !== expected) {
                return { value: true };
            } else {
                throw new Error("Equal");
            }
        }
    };
};
try {
    const result = expect(5).toBe(null);
    console.log(result);
} catch (e) {
    console.error({ error: e.message });
}

/*Given an object or an array, return if it is empty.

An empty object contains no key-value pairs.
An empty array contains no elements.
You may assume the object or array is the output of JSON.parse.

 

Example 1:

Input: obj = {"x": 5, "y": 42}
Output: false
Explanation: The object has 2 key-value pairs so it is not empty.
Example 2:

Input: obj = {}
Output: true
Explanation: The object doesn't have any key-value pairs so it is empty.
Example 3:

Input: obj = [null, false, 0]
Output: false
Explanation: The array has 3 elements so it is not empty*/
function isEmpty(value) {
    
    if (Array.isArray(value)) {
        
        return value.length === 0;
    } else if (typeof value === 'object' && value !== null) {
        
        return Object.keys(value).length === 0;
    }
    
    return false;
}
console.log(isEmpty([]));
console.log(isEmpty(null));
console.log(isEmpty('')); 







































































































































































