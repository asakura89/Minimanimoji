kaomoji taken from [this](http://www.kaomoji.ru/en/) using below script

```javascript
var GetType = obj => obj === undefined ? "Undefined" : Object.prototype.toString.call(obj).match(/^\[object\s+(.*?)\]$/)[1];

var PrevSiblings = (_this, predicate) => {
    let node = _this;
    const siblings = [];
    if (!predicate)
        predicate = (current) => true;
    while (node) {
        if (node.nodeType === Node.ELEMENT_NODE && predicate(node))
            siblings.push(node);
        node = node.previousElementSibling || node.previousSibling;
    }

    return siblings;
};

console.log(
    JSON.stringify(
        Array.prototype
            .slice.call(document.querySelectorAll(".table_kaomoji"))
            .map(tbl => {
                let type1 = PrevSiblings(tbl.parentElement, node => GetType(node) === "HTMLHeadingElement" && node.nodeName === "H2");
                let type2 = PrevSiblings(tbl.parentElement, node => GetType(node) === "HTMLHeadingElement" && node.nodeName === "H3");

                return {
                    Type1: type1 && type1.length > 0 ? (type1[0].textContent || type1[0].innerText).replace("Japanese Emoticons: ", "") : "",
                    Type2: type2 && type2.length > 0 ? (type2[0].textContent || type2[0].innerText) : "",
                    Moji: Array.prototype.slice.call(tbl.querySelectorAll("td > span")).map(el => el.textContent || el.innerText)
                }
            })
    )
);

```