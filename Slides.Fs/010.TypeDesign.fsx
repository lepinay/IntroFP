type EmailContactInfo = string
type Name = string
type PostalContactInfo = string
type ContactV1 = 
    {
    Name: Name;
    EmailContactInfo: EmailContactInfo;
    PostalContactInfo: PostalContactInfo;
    }

type ContactV2 = 
    {
    Name: Name;
    EmailContactInfo: EmailContactInfo option;
    PostalContactInfo: PostalContactInfo option;
    }

type ContactInfo = 
    | EmailOnly of EmailContactInfo
    | PostOnly of PostalContactInfo
    | EmailAndPost of EmailContactInfo * PostalContactInfo

type ContactV3 = 
    {
    Name: Name;
    ContactInfo: ContactInfo;
    }

let updatePostalAddress contact newPostalAddress = 
    let {Name=name; ContactInfo=contactInfo} = contact
    let newContactInfo =
        match contactInfo with
        | EmailOnly email ->
            EmailAndPost (email,newPostalAddress) 
        | PostOnly _ -> // ignore existing address
            PostOnly newPostalAddress 
        | EmailAndPost (email,_) -> // ignore existing address
            EmailAndPost (email,newPostalAddress) 
    // make a new contact
    {Name=name; ContactInfo=newContactInfo}

type PhoneContactInfo  = string
type ContactMethod = 
    | Email of EmailContactInfo 
    | PostalAddress of PostalContactInfo 
    | HomePhone of PhoneContactInfo 
    | WorkPhone of PhoneContactInfo 

type Contact = 
    {
    Name: Name;
    PrimaryContactMethod: ContactMethod;
    SecondaryContactMethods: ContactMethod list;
    }