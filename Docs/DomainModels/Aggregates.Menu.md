 # Domain Models


 ## Menu

 ...csharp
 class Menu
 {
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(Section section);
 }
 ...




 ...json
 {
    "id":
    "00000000-0000-0000-0000-00000000000",
    "name":"Yummy Menu",
    "description":"A menu with yummy food",
    "averageRating":4.5,
    "sections":[
                 {
                    "id":"00000000-0000-0000-0000-00000000000",
                    "name":"Appetizer",
                    "description":"starter",
                    "items":[
                                 {
                    "id": "00000000-0000-0000-0000-00000000000",
                    "name":"Fried Pickles",
                    "description":"Deep fried Pickles"
                    "price":"5.99",
                                    }
                            ]
        }
    ],
    "createdDateTime":"2023-09-30T00:00:00.0000000Z",
    "updatedDateTime":"2023-09-30T00:00:00.0000000Z"
    "hostid":
     "00000000-0000-0000-0000-00000000000",
    "dinnerids":[
         "00000000-0000-0000-0000-00000000000"
    ],
    "menuReviewIds":[
         "00000000-0000-0000-0000-00000000000"
    ],
 }

   
 
 ...