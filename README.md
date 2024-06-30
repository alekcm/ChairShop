<h1>Store app with drag-and-drop support</h1>

**Screen Layout:**
https://www.figma.com/design/3TLO5aT2ve4RZqC3At4n0E/ImpulseDAO%2FTestProject_Layout?node-id=0-1&t=8sudMFEUfdcRAS2i-1

**API for requesting a list of products:**
https://impulsedao.xyz/warpacks/api/tests/get_shopitems_list.php

**API to send json with list of items in cart:**
https://impulsedao.xyz/warpacks/api/tests/checkout.php

**1. Interface layout:**
Layout an adaptive graphical user interface for the application, consisting of the following blocks:
- product store
- shopping cart

**2. Request and display items in the store:**
- asynchronously request from the API a list of products in json format, for each item load its previews (found in the Assets/Images folder of the Unity project)
- display product slots from the received list in the store, each slot should display basic information about the product and its previews
- when hovering the cursor over a product slot, display a popup tooltip with additional information about the product (title, description)
- the product slot should appear smoothly after loading all necessary data, during data loading the slot should display a preloader

**3. Adding items to the cart using drag-n-drop:**
- on dragging with mouse the product slot in the store should move with it
- on release check if the slot is in the shopping cart area
- if true, the item is added to the shopping cart and the total sum is increased
- otherwise, if the item slot is not in the shopping cart area, the item is returned to the store
- if the item is added to the cart again, the counter of its quantity is increased, the sum is recalculated

**4. Removing items from the cart using drag-n-drop:**
- on dragging with mouse the slot of the product in the cart should move with it
- on release check if the slot of the item is in the shopping cart area
- if true, the item is removed from the shopping cart and placed back in the store, the purchase amount is reduced
- otherwise, if the item slot is not in the shopping cart area, the item is returned to the shopping cart

**5. Deleting items from the cart using the button:**
- when the button with the trash can icon is pressed, all items are removed from the cart and placed in the store
- total purchase amount is updated

**6. Making a purchase:**
- when the "Checkout" button is clicked, a final json file is generated with the IDs of the items in the cart and their quantities in the order they were added
- send the generated json to API using POST request
- display a modal preloader (a layer overlapping the application screen) during sending

**7. Publishing under WebGL:**
- the final project must compile and work under the WebGL platform
- the final project must support the ability to expand to full screen (browser window) or resize the browser window, while the size of elements and their binding relative to the corners and borders of the screen must not change.

**Attention!**
**It is not necessary to complete all tasks, each task will be evaluated separately.**


