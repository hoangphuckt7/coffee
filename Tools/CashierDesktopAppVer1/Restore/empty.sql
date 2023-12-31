PGDMP     8    	                z            BlueBirdCoffee    14.5 (Debian 14.5-1.pgdg110+1)    14.4 �               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16384    BlueBirdCoffee    DATABASE     d   CREATE DATABASE "BlueBirdCoffee" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'en_US.utf8';
     DROP DATABASE "BlueBirdCoffee";
                postgres    false                        2615    16385    hangfire    SCHEMA        CREATE SCHEMA hangfire;
    DROP SCHEMA hangfire;
                postgres    false            �            1259    16392    counter    TABLE     �   CREATE TABLE hangfire.counter (
    id bigint NOT NULL,
    key text NOT NULL,
    value bigint NOT NULL,
    expireat timestamp without time zone
);
    DROP TABLE hangfire.counter;
       hangfire         heap    postgres    false    6            �            1259    16391    counter_id_seq    SEQUENCE     y   CREATE SEQUENCE hangfire.counter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE hangfire.counter_id_seq;
       hangfire          postgres    false    212    6                       0    0    counter_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE hangfire.counter_id_seq OWNED BY hangfire.counter.id;
          hangfire          postgres    false    211            �            1259    16400    hash    TABLE     �   CREATE TABLE hangfire.hash (
    id bigint NOT NULL,
    key text NOT NULL,
    field text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.hash;
       hangfire         heap    postgres    false    6            �            1259    16399    hash_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.hash_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.hash_id_seq;
       hangfire          postgres    false    214    6                       0    0    hash_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.hash_id_seq OWNED BY hangfire.hash.id;
          hangfire          postgres    false    213            �            1259    16411    job    TABLE     '  CREATE TABLE hangfire.job (
    id bigint NOT NULL,
    stateid bigint,
    statename text,
    invocationdata text NOT NULL,
    arguments text NOT NULL,
    createdat timestamp without time zone NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.job;
       hangfire         heap    postgres    false    6            �            1259    16410 
   job_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.job_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.job_id_seq;
       hangfire          postgres    false    6    216                       0    0 
   job_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.job_id_seq OWNED BY hangfire.job.id;
          hangfire          postgres    false    215            �            1259    16471    jobparameter    TABLE     �   CREATE TABLE hangfire.jobparameter (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    value text,
    updatecount integer DEFAULT 0 NOT NULL
);
 "   DROP TABLE hangfire.jobparameter;
       hangfire         heap    postgres    false    6            �            1259    16470    jobparameter_id_seq    SEQUENCE     ~   CREATE SEQUENCE hangfire.jobparameter_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE hangfire.jobparameter_id_seq;
       hangfire          postgres    false    6    227                       0    0    jobparameter_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE hangfire.jobparameter_id_seq OWNED BY hangfire.jobparameter.id;
          hangfire          postgres    false    226            �            1259    16436    jobqueue    TABLE     �   CREATE TABLE hangfire.jobqueue (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    queue text NOT NULL,
    fetchedat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.jobqueue;
       hangfire         heap    postgres    false    6            �            1259    16435    jobqueue_id_seq    SEQUENCE     z   CREATE SEQUENCE hangfire.jobqueue_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE hangfire.jobqueue_id_seq;
       hangfire          postgres    false    6    220                       0    0    jobqueue_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE hangfire.jobqueue_id_seq OWNED BY hangfire.jobqueue.id;
          hangfire          postgres    false    219            �            1259    16444    list    TABLE     �   CREATE TABLE hangfire.list (
    id bigint NOT NULL,
    key text NOT NULL,
    value text,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.list;
       hangfire         heap    postgres    false    6            �            1259    16443    list_id_seq    SEQUENCE     v   CREATE SEQUENCE hangfire.list_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE hangfire.list_id_seq;
       hangfire          postgres    false    6    222                        0    0    list_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE hangfire.list_id_seq OWNED BY hangfire.list.id;
          hangfire          postgres    false    221            �            1259    16485    lock    TABLE     �   CREATE TABLE hangfire.lock (
    resource text NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL,
    acquired timestamp without time zone
);
    DROP TABLE hangfire.lock;
       hangfire         heap    postgres    false    6            �            1259    16386    schema    TABLE     ?   CREATE TABLE hangfire.schema (
    version integer NOT NULL
);
    DROP TABLE hangfire.schema;
       hangfire         heap    postgres    false    6            �            1259    16452    server    TABLE     �   CREATE TABLE hangfire.server (
    id text NOT NULL,
    data text,
    lastheartbeat timestamp without time zone NOT NULL,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.server;
       hangfire         heap    postgres    false    6            �            1259    16460    set    TABLE     �   CREATE TABLE hangfire.set (
    id bigint NOT NULL,
    key text NOT NULL,
    score double precision NOT NULL,
    value text NOT NULL,
    expireat timestamp without time zone,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.set;
       hangfire         heap    postgres    false    6            �            1259    16459 
   set_id_seq    SEQUENCE     u   CREATE SEQUENCE hangfire.set_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE hangfire.set_id_seq;
       hangfire          postgres    false    6    225            !           0    0 
   set_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE hangfire.set_id_seq OWNED BY hangfire.set.id;
          hangfire          postgres    false    224            �            1259    16421    state    TABLE     �   CREATE TABLE hangfire.state (
    id bigint NOT NULL,
    jobid bigint NOT NULL,
    name text NOT NULL,
    reason text,
    createdat timestamp without time zone NOT NULL,
    data text,
    updatecount integer DEFAULT 0 NOT NULL
);
    DROP TABLE hangfire.state;
       hangfire         heap    postgres    false    6            �            1259    16420    state_id_seq    SEQUENCE     w   CREATE SEQUENCE hangfire.state_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE hangfire.state_id_seq;
       hangfire          postgres    false    218    6            "           0    0    state_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE hangfire.state_id_seq OWNED BY hangfire.state.id;
          hangfire          postgres    false    217            �            1259    16676    AspNetRoleClaims    TABLE     �   CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetRoleClaims";
       public         heap    postgres    false            �            1259    16681    AspNetRoleClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetRoleClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetRoleClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    229            �            1259    16682    AspNetRoles    TABLE     �   CREATE TABLE public."AspNetRoles" (
    "Id" text NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" text
);
 !   DROP TABLE public."AspNetRoles";
       public         heap    postgres    false            �            1259    16687    AspNetUserClaims    TABLE     �   CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" text NOT NULL,
    "ClaimType" text,
    "ClaimValue" text
);
 &   DROP TABLE public."AspNetUserClaims";
       public         heap    postgres    false            �            1259    16692    AspNetUserClaims_Id_seq    SEQUENCE     �   ALTER TABLE public."AspNetUserClaims" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."AspNetUserClaims_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    232            �            1259    16693    AspNetUserLogins    TABLE     �   CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text,
    "UserId" text NOT NULL
);
 &   DROP TABLE public."AspNetUserLogins";
       public         heap    postgres    false            �            1259    16698    AspNetUserRoles    TABLE     b   CREATE TABLE public."AspNetUserRoles" (
    "UserId" text NOT NULL,
    "RoleId" text NOT NULL
);
 %   DROP TABLE public."AspNetUserRoles";
       public         heap    postgres    false            �            1259    16703    AspNetUserTokens    TABLE     �   CREATE TABLE public."AspNetUserTokens" (
    "UserId" text NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text
);
 &   DROP TABLE public."AspNetUserTokens";
       public         heap    postgres    false            �            1259    16708    AspNetUsers    TABLE     �  CREATE TABLE public."AspNetUsers" (
    "Id" text NOT NULL,
    "Fullname" text NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean NOT NULL,
    "PasswordHash" text,
    "SecurityStamp" text,
    "ConcurrencyStamp" text,
    "PhoneNumber" text,
    "PhoneNumberConfirmed" boolean NOT NULL,
    "TwoFactorEnabled" boolean NOT NULL,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean NOT NULL,
    "AccessFailedCount" integer NOT NULL
);
 !   DROP TABLE public."AspNetUsers";
       public         heap    postgres    false            �            1259    16713 
   BillOrders    TABLE     ^   CREATE TABLE public."BillOrders" (
    "OrderId" uuid NOT NULL,
    "BillId" uuid NOT NULL
);
     DROP TABLE public."BillOrders";
       public         heap    postgres    false            �            1259    16716    Bills    TABLE     �  CREATE TABLE public."Bills" (
    "Id" uuid NOT NULL,
    "ItemMissingReason" text,
    "Coupon" double precision,
    "Discount" double precision,
    "IsTakeAway" boolean NOT NULL,
    "BillNumber" integer NOT NULL,
    "Total" double precision NOT NULL,
    "CouponCode" text,
    "CasherId" text,
    "CustomerId" text,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
    DROP TABLE public."Bills";
       public         heap    postgres    false            �            1259    16721 
   Categories    TABLE     �   CREATE TABLE public."Categories" (
    "Id" uuid NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
     DROP TABLE public."Categories";
       public         heap    postgres    false            �            1259    16726    Coupons    TABLE     �  CREATE TABLE public."Coupons" (
    "Id" uuid NOT NULL,
    "FromDate" timestamp without time zone,
    "ToDate" timestamp without time zone,
    "Limit" integer,
    "Maximum" double precision,
    "Minium" double precision,
    "Discount" double precision,
    "Default" boolean NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
    DROP TABLE public."Coupons";
       public         heap    postgres    false            �            1259    16731    Floors    TABLE     �   CREATE TABLE public."Floors" (
    "Id" uuid NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
    DROP TABLE public."Floors";
       public         heap    postgres    false            �            1259    16736 
   ItemImages    TABLE       CREATE TABLE public."ItemImages" (
    "Id" uuid NOT NULL,
    "Image" bytea,
    "ItemId" uuid NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
     DROP TABLE public."ItemImages";
       public         heap    postgres    false            �            1259    16741    Items    TABLE     \  CREATE TABLE public."Items" (
    "Id" uuid NOT NULL,
    "Name" text,
    "Price" double precision NOT NULL,
    "Available" boolean NOT NULL,
    "CategoryId" uuid NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
    DROP TABLE public."Items";
       public         heap    postgres    false            �            1259    16746    OrderDetails    TABLE     8  CREATE TABLE public."OrderDetails" (
    "ItemId" uuid NOT NULL,
    "OrderId" uuid NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "Quantity" integer NOT NULL,
    "FinalQuantity" integer NOT NULL,
    "MissingReason" text,
    "Price" double precision NOT NULL,
    "Description" text
);
 "   DROP TABLE public."OrderDetails";
       public         heap    postgres    false            �            1259    16751    Orders    TABLE       CREATE TABLE public."Orders" (
    "Id" uuid NOT NULL,
    "OrderNumber" integer NOT NULL,
    "IsCompleted" boolean NOT NULL,
    "IsCheckout" boolean NOT NULL,
    "IsRejected" boolean NOT NULL,
    "IsMissing" boolean NOT NULL,
    "RejectedReason" text,
    "TableId" uuid,
    "EmployeeId" text,
    "UserRejectedId" text,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL,
    "BartenderId" text
);
    DROP TABLE public."Orders";
       public         heap    postgres    false            �            1259    16756    SystemSettings    TABLE     T   CREATE TABLE public."SystemSettings" (
    "Key" text NOT NULL,
    "Value" text
);
 $   DROP TABLE public."SystemSettings";
       public         heap    postgres    false            �            1259    16761    Tables    TABLE     �  CREATE TABLE public."Tables" (
    "Id" uuid NOT NULL,
    "CurrentOrder" integer NOT NULL,
    "Position" text NOT NULL,
    "Size" text NOT NULL,
    "Shape" text NOT NULL,
    "Rotation" integer NOT NULL,
    "FloorId" uuid NOT NULL,
    "Description" text,
    "DateCreated" timestamp without time zone NOT NULL,
    "DateUpdated" timestamp without time zone NOT NULL,
    "IsDeleted" boolean NOT NULL
);
    DROP TABLE public."Tables";
       public         heap    postgres    false            �            1259    16766    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            �           2604    16518 
   counter id    DEFAULT     l   ALTER TABLE ONLY hangfire.counter ALTER COLUMN id SET DEFAULT nextval('hangfire.counter_id_seq'::regclass);
 ;   ALTER TABLE hangfire.counter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    212    211    212            �           2604    16527    hash id    DEFAULT     f   ALTER TABLE ONLY hangfire.hash ALTER COLUMN id SET DEFAULT nextval('hangfire.hash_id_seq'::regclass);
 8   ALTER TABLE hangfire.hash ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    214    213    214            �           2604    16537    job id    DEFAULT     d   ALTER TABLE ONLY hangfire.job ALTER COLUMN id SET DEFAULT nextval('hangfire.job_id_seq'::regclass);
 7   ALTER TABLE hangfire.job ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    216    215    216            �           2604    16587    jobparameter id    DEFAULT     v   ALTER TABLE ONLY hangfire.jobparameter ALTER COLUMN id SET DEFAULT nextval('hangfire.jobparameter_id_seq'::regclass);
 @   ALTER TABLE hangfire.jobparameter ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    226    227    227            �           2604    16610    jobqueue id    DEFAULT     n   ALTER TABLE ONLY hangfire.jobqueue ALTER COLUMN id SET DEFAULT nextval('hangfire.jobqueue_id_seq'::regclass);
 <   ALTER TABLE hangfire.jobqueue ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    220    219    220            �           2604    16630    list id    DEFAULT     f   ALTER TABLE ONLY hangfire.list ALTER COLUMN id SET DEFAULT nextval('hangfire.list_id_seq'::regclass);
 8   ALTER TABLE hangfire.list ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    222    221    222            �           2604    16639    set id    DEFAULT     d   ALTER TABLE ONLY hangfire.set ALTER COLUMN id SET DEFAULT nextval('hangfire.set_id_seq'::regclass);
 7   ALTER TABLE hangfire.set ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    224    225    225            �           2604    16564    state id    DEFAULT     h   ALTER TABLE ONLY hangfire.state ALTER COLUMN id SET DEFAULT nextval('hangfire.state_id_seq'::regclass);
 9   ALTER TABLE hangfire.state ALTER COLUMN id DROP DEFAULT;
       hangfire          postgres    false    217    218    218            �          0    16392    counter 
   TABLE DATA           =   COPY hangfire.counter (id, key, value, expireat) FROM stdin;
    hangfire          postgres    false    212   ��       �          0    16400    hash 
   TABLE DATA           N   COPY hangfire.hash (id, key, field, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    214   ��       �          0    16411    job 
   TABLE DATA           t   COPY hangfire.job (id, stateid, statename, invocationdata, arguments, createdat, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    216   �       �          0    16471    jobparameter 
   TABLE DATA           M   COPY hangfire.jobparameter (id, jobid, name, value, updatecount) FROM stdin;
    hangfire          postgres    false    227   ��       �          0    16436    jobqueue 
   TABLE DATA           N   COPY hangfire.jobqueue (id, jobid, queue, fetchedat, updatecount) FROM stdin;
    hangfire          postgres    false    220   &�       �          0    16444    list 
   TABLE DATA           G   COPY hangfire.list (id, key, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    222   C�       �          0    16485    lock 
   TABLE DATA           A   COPY hangfire.lock (resource, updatecount, acquired) FROM stdin;
    hangfire          postgres    false    228   `�       �          0    16386    schema 
   TABLE DATA           +   COPY hangfire.schema (version) FROM stdin;
    hangfire          postgres    false    210   }�       �          0    16452    server 
   TABLE DATA           H   COPY hangfire.server (id, data, lastheartbeat, updatecount) FROM stdin;
    hangfire          postgres    false    223   ��       �          0    16460    set 
   TABLE DATA           M   COPY hangfire.set (id, key, score, value, expireat, updatecount) FROM stdin;
    hangfire          postgres    false    225   A�       �          0    16421    state 
   TABLE DATA           X   COPY hangfire.state (id, jobid, name, reason, createdat, data, updatecount) FROM stdin;
    hangfire          postgres    false    218   ��                  0    16676    AspNetRoleClaims 
   TABLE DATA           W   COPY public."AspNetRoleClaims" ("Id", "RoleId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    229   W�                 0    16682    AspNetRoles 
   TABLE DATA           [   COPY public."AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp") FROM stdin;
    public          postgres    false    231   t�                 0    16687    AspNetUserClaims 
   TABLE DATA           W   COPY public."AspNetUserClaims" ("Id", "UserId", "ClaimType", "ClaimValue") FROM stdin;
    public          postgres    false    232   ��                 0    16693    AspNetUserLogins 
   TABLE DATA           m   COPY public."AspNetUserLogins" ("LoginProvider", "ProviderKey", "ProviderDisplayName", "UserId") FROM stdin;
    public          postgres    false    234   ��                 0    16698    AspNetUserRoles 
   TABLE DATA           ?   COPY public."AspNetUserRoles" ("UserId", "RoleId") FROM stdin;
    public          postgres    false    235   �                 0    16703    AspNetUserTokens 
   TABLE DATA           X   COPY public."AspNetUserTokens" ("UserId", "LoginProvider", "Name", "Value") FROM stdin;
    public          postgres    false    236   J�                 0    16708    AspNetUsers 
   TABLE DATA           Y  COPY public."AspNetUsers" ("Id", "Fullname", "IsDeleted", "DateCreated", "DateUpdated", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount") FROM stdin;
    public          postgres    false    237   g�       	          0    16713 
   BillOrders 
   TABLE DATA           ;   COPY public."BillOrders" ("OrderId", "BillId") FROM stdin;
    public          postgres    false    238   j�       
          0    16716    Bills 
   TABLE DATA           �   COPY public."Bills" ("Id", "ItemMissingReason", "Coupon", "Discount", "IsTakeAway", "BillNumber", "Total", "CouponCode", "CasherId", "CustomerId", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    239   ��                 0    16721 
   Categories 
   TABLE DATA           f   COPY public."Categories" ("Id", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    240   ��                 0    16726    Coupons 
   TABLE DATA           �   COPY public."Coupons" ("Id", "FromDate", "ToDate", "Limit", "Maximum", "Minium", "Discount", "Default", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    241   ��                 0    16731    Floors 
   TABLE DATA           b   COPY public."Floors" ("Id", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    242   ��                 0    16736 
   ItemImages 
   TABLE DATA           y   COPY public."ItemImages" ("Id", "Image", "ItemId", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    243   ��                 0    16741    Items 
   TABLE DATA           �   COPY public."Items" ("Id", "Name", "Price", "Available", "CategoryId", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    244   �                 0    16746    OrderDetails 
   TABLE DATA           �   COPY public."OrderDetails" ("ItemId", "OrderId", "DateUpdated", "Quantity", "FinalQuantity", "MissingReason", "Price", "Description") FROM stdin;
    public          postgres    false    245   5�                 0    16751    Orders 
   TABLE DATA           �   COPY public."Orders" ("Id", "OrderNumber", "IsCompleted", "IsCheckout", "IsRejected", "IsMissing", "RejectedReason", "TableId", "EmployeeId", "UserRejectedId", "Description", "DateCreated", "DateUpdated", "IsDeleted", "BartenderId") FROM stdin;
    public          postgres    false    246   R�                 0    16756    SystemSettings 
   TABLE DATA           :   COPY public."SystemSettings" ("Key", "Value") FROM stdin;
    public          postgres    false    247   o�                 0    16761    Tables 
   TABLE DATA           �   COPY public."Tables" ("Id", "CurrentOrder", "Position", "Size", "Shape", "Rotation", "FloorId", "Description", "DateCreated", "DateUpdated", "IsDeleted") FROM stdin;
    public          postgres    false    248   ��                 0    16766    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    249   ��       #           0    0    counter_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('hangfire.counter_id_seq', 2, true);
          hangfire          postgres    false    211            $           0    0    hash_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('hangfire.hash_id_seq', 35, true);
          hangfire          postgres    false    213            %           0    0 
   job_id_seq    SEQUENCE SET     :   SELECT pg_catalog.setval('hangfire.job_id_seq', 1, true);
          hangfire          postgres    false    215            &           0    0    jobparameter_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('hangfire.jobparameter_id_seq', 5, true);
          hangfire          postgres    false    226            '           0    0    jobqueue_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('hangfire.jobqueue_id_seq', 11, true);
          hangfire          postgres    false    219            (           0    0    list_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('hangfire.list_id_seq', 1, false);
          hangfire          postgres    false    221            )           0    0 
   set_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('hangfire.set_id_seq', 54, true);
          hangfire          postgres    false    224            *           0    0    state_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('hangfire.state_id_seq', 43, true);
          hangfire          postgres    false    217            +           0    0    AspNetRoleClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);
          public          postgres    false    230            ,           0    0    AspNetUserClaims_Id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);
          public          postgres    false    233            �           2606    16520    counter counter_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY hangfire.counter
    ADD CONSTRAINT counter_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY hangfire.counter DROP CONSTRAINT counter_pkey;
       hangfire            postgres    false    212            �           2606    16655    hash hash_key_field_key 
   CONSTRAINT     Z   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_key_field_key UNIQUE (key, field);
 C   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_key_field_key;
       hangfire            postgres    false    214    214            �           2606    16529    hash hash_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.hash
    ADD CONSTRAINT hash_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.hash DROP CONSTRAINT hash_pkey;
       hangfire            postgres    false    214            �           2606    16539    job job_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.job
    ADD CONSTRAINT job_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.job DROP CONSTRAINT job_pkey;
       hangfire            postgres    false    216                       2606    16589    jobparameter jobparameter_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_pkey PRIMARY KEY (id);
 J   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_pkey;
       hangfire            postgres    false    227                       2606    16612    jobqueue jobqueue_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY hangfire.jobqueue
    ADD CONSTRAINT jobqueue_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY hangfire.jobqueue DROP CONSTRAINT jobqueue_pkey;
       hangfire            postgres    false    220                       2606    16632    list list_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY hangfire.list
    ADD CONSTRAINT list_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY hangfire.list DROP CONSTRAINT list_pkey;
       hangfire            postgres    false    222                       2606    16511    lock lock_resource_key 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.lock
    ADD CONSTRAINT lock_resource_key UNIQUE (resource);
 B   ALTER TABLE ONLY hangfire.lock DROP CONSTRAINT lock_resource_key;
       hangfire            postgres    false    228            �           2606    16390    schema schema_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY hangfire.schema
    ADD CONSTRAINT schema_pkey PRIMARY KEY (version);
 >   ALTER TABLE ONLY hangfire.schema DROP CONSTRAINT schema_pkey;
       hangfire            postgres    false    210            	           2606    16658    server server_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY hangfire.server
    ADD CONSTRAINT server_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY hangfire.server DROP CONSTRAINT server_pkey;
       hangfire            postgres    false    223                       2606    16660    set set_key_value_key 
   CONSTRAINT     X   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_key_value_key UNIQUE (key, value);
 A   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_key_value_key;
       hangfire            postgres    false    225    225                       2606    16641    set set_pkey 
   CONSTRAINT     L   ALTER TABLE ONLY hangfire.set
    ADD CONSTRAINT set_pkey PRIMARY KEY (id);
 8   ALTER TABLE ONLY hangfire.set DROP CONSTRAINT set_pkey;
       hangfire            postgres    false    225            �           2606    16566    state state_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_pkey;
       hangfire            postgres    false    218                       2606    16835 $   AspNetRoleClaims PK_AspNetRoleClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "PK_AspNetRoleClaims";
       public            postgres    false    229                       2606    16837    AspNetRoles PK_AspNetRoles 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetRoles"
    ADD CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetRoles" DROP CONSTRAINT "PK_AspNetRoles";
       public            postgres    false    231                       2606    16839 $   AspNetUserClaims PK_AspNetUserClaims 
   CONSTRAINT     h   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id");
 R   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "PK_AspNetUserClaims";
       public            postgres    false    232                        2606    16841 $   AspNetUserLogins PK_AspNetUserLogins 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey");
 R   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "PK_AspNetUserLogins";
       public            postgres    false    234    234            #           2606    16843 "   AspNetUserRoles PK_AspNetUserRoles 
   CONSTRAINT     t   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId");
 P   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "PK_AspNetUserRoles";
       public            postgres    false    235    235            %           2606    16845 $   AspNetUserTokens PK_AspNetUserTokens 
   CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name");
 R   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "PK_AspNetUserTokens";
       public            postgres    false    236    236    236            (           2606    16847    AspNetUsers PK_AspNetUsers 
   CONSTRAINT     ^   ALTER TABLE ONLY public."AspNetUsers"
    ADD CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."AspNetUsers" DROP CONSTRAINT "PK_AspNetUsers";
       public            postgres    false    237            ,           2606    16849    BillOrders PK_BillOrders 
   CONSTRAINT     k   ALTER TABLE ONLY public."BillOrders"
    ADD CONSTRAINT "PK_BillOrders" PRIMARY KEY ("OrderId", "BillId");
 F   ALTER TABLE ONLY public."BillOrders" DROP CONSTRAINT "PK_BillOrders";
       public            postgres    false    238    238            0           2606    16851    Bills PK_Bills 
   CONSTRAINT     R   ALTER TABLE ONLY public."Bills"
    ADD CONSTRAINT "PK_Bills" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Bills" DROP CONSTRAINT "PK_Bills";
       public            postgres    false    239            2           2606    16853    Categories PK_Categories 
   CONSTRAINT     \   ALTER TABLE ONLY public."Categories"
    ADD CONSTRAINT "PK_Categories" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."Categories" DROP CONSTRAINT "PK_Categories";
       public            postgres    false    240            5           2606    16855    Coupons PK_Coupons 
   CONSTRAINT     V   ALTER TABLE ONLY public."Coupons"
    ADD CONSTRAINT "PK_Coupons" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Coupons" DROP CONSTRAINT "PK_Coupons";
       public            postgres    false    241            7           2606    16857    Floors PK_Floors 
   CONSTRAINT     T   ALTER TABLE ONLY public."Floors"
    ADD CONSTRAINT "PK_Floors" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Floors" DROP CONSTRAINT "PK_Floors";
       public            postgres    false    242            :           2606    16859    ItemImages PK_ItemImages 
   CONSTRAINT     \   ALTER TABLE ONLY public."ItemImages"
    ADD CONSTRAINT "PK_ItemImages" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."ItemImages" DROP CONSTRAINT "PK_ItemImages";
       public            postgres    false    243            =           2606    16861    Items PK_Items 
   CONSTRAINT     R   ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "PK_Items" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Items" DROP CONSTRAINT "PK_Items";
       public            postgres    false    244            @           2606    16863    OrderDetails PK_OrderDetails 
   CONSTRAINT     o   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "PK_OrderDetails" PRIMARY KEY ("OrderId", "ItemId");
 J   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "PK_OrderDetails";
       public            postgres    false    245    245            E           2606    16865    Orders PK_Orders 
   CONSTRAINT     T   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_Orders" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "PK_Orders";
       public            postgres    false    246            G           2606    16867     SystemSettings PK_SystemSettings 
   CONSTRAINT     e   ALTER TABLE ONLY public."SystemSettings"
    ADD CONSTRAINT "PK_SystemSettings" PRIMARY KEY ("Key");
 N   ALTER TABLE ONLY public."SystemSettings" DROP CONSTRAINT "PK_SystemSettings";
       public            postgres    false    247            J           2606    16869    Tables PK_Tables 
   CONSTRAINT     T   ALTER TABLE ONLY public."Tables"
    ADD CONSTRAINT "PK_Tables" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Tables" DROP CONSTRAINT "PK_Tables";
       public            postgres    false    248            L           2606    16871 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    249            �           1259    16502    ix_hangfire_counter_expireat    INDEX     V   CREATE INDEX ix_hangfire_counter_expireat ON hangfire.counter USING btree (expireat);
 2   DROP INDEX hangfire.ix_hangfire_counter_expireat;
       hangfire            postgres    false    212            �           1259    16649    ix_hangfire_counter_key    INDEX     L   CREATE INDEX ix_hangfire_counter_key ON hangfire.counter USING btree (key);
 -   DROP INDEX hangfire.ix_hangfire_counter_key;
       hangfire            postgres    false    212            �           1259    16667    ix_hangfire_hash_expireat    INDEX     P   CREATE INDEX ix_hangfire_hash_expireat ON hangfire.hash USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_hash_expireat;
       hangfire            postgres    false    214            �           1259    16664    ix_hangfire_job_expireat    INDEX     N   CREATE INDEX ix_hangfire_job_expireat ON hangfire.job USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_job_expireat;
       hangfire            postgres    false    216            �           1259    16656    ix_hangfire_job_statename    INDEX     P   CREATE INDEX ix_hangfire_job_statename ON hangfire.job USING btree (statename);
 /   DROP INDEX hangfire.ix_hangfire_job_statename;
       hangfire            postgres    false    216                       1259    16661 %   ix_hangfire_jobparameter_jobidandname    INDEX     g   CREATE INDEX ix_hangfire_jobparameter_jobidandname ON hangfire.jobparameter USING btree (jobid, name);
 ;   DROP INDEX hangfire.ix_hangfire_jobparameter_jobidandname;
       hangfire            postgres    false    227    227                        1259    16621 "   ix_hangfire_jobqueue_jobidandqueue    INDEX     a   CREATE INDEX ix_hangfire_jobqueue_jobidandqueue ON hangfire.jobqueue USING btree (jobid, queue);
 8   DROP INDEX hangfire.ix_hangfire_jobqueue_jobidandqueue;
       hangfire            postgres    false    220    220                       1259    16514 &   ix_hangfire_jobqueue_queueandfetchedat    INDEX     i   CREATE INDEX ix_hangfire_jobqueue_queueandfetchedat ON hangfire.jobqueue USING btree (queue, fetchedat);
 <   DROP INDEX hangfire.ix_hangfire_jobqueue_queueandfetchedat;
       hangfire            postgres    false    220    220                       1259    16665    ix_hangfire_list_expireat    INDEX     P   CREATE INDEX ix_hangfire_list_expireat ON hangfire.list USING btree (expireat);
 /   DROP INDEX hangfire.ix_hangfire_list_expireat;
       hangfire            postgres    false    222            
           1259    16666    ix_hangfire_set_expireat    INDEX     N   CREATE INDEX ix_hangfire_set_expireat ON hangfire.set USING btree (expireat);
 .   DROP INDEX hangfire.ix_hangfire_set_expireat;
       hangfire            postgres    false    225                       1259    16675    ix_hangfire_set_key_score    INDEX     Q   CREATE INDEX ix_hangfire_set_key_score ON hangfire.set USING btree (key, score);
 /   DROP INDEX hangfire.ix_hangfire_set_key_score;
       hangfire            postgres    false    225    225            �           1259    16574    ix_hangfire_state_jobid    INDEX     L   CREATE INDEX ix_hangfire_state_jobid ON hangfire.state USING btree (jobid);
 -   DROP INDEX hangfire.ix_hangfire_state_jobid;
       hangfire            postgres    false    218                       1259    16662    jobqueue_queue_fetchat_jobid    INDEX     f   CREATE INDEX jobqueue_queue_fetchat_jobid ON hangfire.jobqueue USING btree (queue, fetchedat, jobid);
 2   DROP INDEX hangfire.jobqueue_queue_fetchat_jobid;
       hangfire            postgres    false    220    220    220            &           1259    16872 
   EmailIndex    INDEX     S   CREATE INDEX "EmailIndex" ON public."AspNetUsers" USING btree ("NormalizedEmail");
     DROP INDEX public."EmailIndex";
       public            postgres    false    237                       1259    16873    IX_AspNetRoleClaims_RoleId    INDEX     _   CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON public."AspNetRoleClaims" USING btree ("RoleId");
 0   DROP INDEX public."IX_AspNetRoleClaims_RoleId";
       public            postgres    false    229                       1259    16874    IX_AspNetUserClaims_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserClaims_UserId" ON public."AspNetUserClaims" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserClaims_UserId";
       public            postgres    false    232                       1259    16875    IX_AspNetUserLogins_UserId    INDEX     _   CREATE INDEX "IX_AspNetUserLogins_UserId" ON public."AspNetUserLogins" USING btree ("UserId");
 0   DROP INDEX public."IX_AspNetUserLogins_UserId";
       public            postgres    false    234            !           1259    16876    IX_AspNetUserRoles_RoleId    INDEX     ]   CREATE INDEX "IX_AspNetUserRoles_RoleId" ON public."AspNetUserRoles" USING btree ("RoleId");
 /   DROP INDEX public."IX_AspNetUserRoles_RoleId";
       public            postgres    false    235            *           1259    16877    IX_BillOrders_BillId    INDEX     S   CREATE INDEX "IX_BillOrders_BillId" ON public."BillOrders" USING btree ("BillId");
 *   DROP INDEX public."IX_BillOrders_BillId";
       public            postgres    false    238            -           1259    16878    IX_Bills_CasherId    INDEX     M   CREATE INDEX "IX_Bills_CasherId" ON public."Bills" USING btree ("CasherId");
 '   DROP INDEX public."IX_Bills_CasherId";
       public            postgres    false    239            .           1259    16879    IX_Bills_CustomerId    INDEX     Q   CREATE INDEX "IX_Bills_CustomerId" ON public."Bills" USING btree ("CustomerId");
 )   DROP INDEX public."IX_Bills_CustomerId";
       public            postgres    false    239            3           1259    16880    IX_Coupons_Description    INDEX     ^   CREATE UNIQUE INDEX "IX_Coupons_Description" ON public."Coupons" USING btree ("Description");
 ,   DROP INDEX public."IX_Coupons_Description";
       public            postgres    false    241            8           1259    16881    IX_ItemImages_ItemId    INDEX     S   CREATE INDEX "IX_ItemImages_ItemId" ON public."ItemImages" USING btree ("ItemId");
 *   DROP INDEX public."IX_ItemImages_ItemId";
       public            postgres    false    243            ;           1259    16882    IX_Items_CategoryId    INDEX     Q   CREATE INDEX "IX_Items_CategoryId" ON public."Items" USING btree ("CategoryId");
 )   DROP INDEX public."IX_Items_CategoryId";
       public            postgres    false    244            >           1259    16883    IX_OrderDetails_ItemId    INDEX     W   CREATE INDEX "IX_OrderDetails_ItemId" ON public."OrderDetails" USING btree ("ItemId");
 ,   DROP INDEX public."IX_OrderDetails_ItemId";
       public            postgres    false    245            A           1259    16884    IX_Orders_EmployeeId    INDEX     S   CREATE INDEX "IX_Orders_EmployeeId" ON public."Orders" USING btree ("EmployeeId");
 *   DROP INDEX public."IX_Orders_EmployeeId";
       public            postgres    false    246            B           1259    16885    IX_Orders_TableId    INDEX     M   CREATE INDEX "IX_Orders_TableId" ON public."Orders" USING btree ("TableId");
 '   DROP INDEX public."IX_Orders_TableId";
       public            postgres    false    246            C           1259    16886    IX_Orders_UserRejectedId    INDEX     [   CREATE INDEX "IX_Orders_UserRejectedId" ON public."Orders" USING btree ("UserRejectedId");
 .   DROP INDEX public."IX_Orders_UserRejectedId";
       public            postgres    false    246            H           1259    16887    IX_Tables_FloorId    INDEX     M   CREATE INDEX "IX_Tables_FloorId" ON public."Tables" USING btree ("FloorId");
 '   DROP INDEX public."IX_Tables_FloorId";
       public            postgres    false    248                       1259    16888    RoleNameIndex    INDEX     \   CREATE UNIQUE INDEX "RoleNameIndex" ON public."AspNetRoles" USING btree ("NormalizedName");
 #   DROP INDEX public."RoleNameIndex";
       public            postgres    false    231            )           1259    16889    UserNameIndex    INDEX     `   CREATE UNIQUE INDEX "UserNameIndex" ON public."AspNetUsers" USING btree ("NormalizedUserName");
 #   DROP INDEX public."UserNameIndex";
       public            postgres    false    237            N           2606    16598 $   jobparameter jobparameter_jobid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY hangfire.jobparameter
    ADD CONSTRAINT jobparameter_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY hangfire.jobparameter DROP CONSTRAINT jobparameter_jobid_fkey;
       hangfire          postgres    false    3324    227    216            M           2606    16575    state state_jobid_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY hangfire.state
    ADD CONSTRAINT state_jobid_fkey FOREIGN KEY (jobid) REFERENCES hangfire.job(id) ON UPDATE CASCADE ON DELETE CASCADE;
 B   ALTER TABLE ONLY hangfire.state DROP CONSTRAINT state_jobid_fkey;
       hangfire          postgres    false    3324    218    216            O           2606    16890 7   AspNetRoleClaims FK_AspNetRoleClaims_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetRoleClaims"
    ADD CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetRoleClaims" DROP CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId";
       public          postgres    false    229    3353    231            P           2606    16895 7   AspNetUserClaims FK_AspNetUserClaims_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserClaims"
    ADD CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserClaims" DROP CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId";
       public          postgres    false    3368    237    232            Q           2606    16900 7   AspNetUserLogins FK_AspNetUserLogins_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserLogins"
    ADD CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserLogins" DROP CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId";
       public          postgres    false    234    237    3368            R           2606    16905 5   AspNetUserRoles FK_AspNetUserRoles_AspNetRoles_RoleId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."AspNetRoles"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId";
       public          postgres    false    235    231    3353            S           2606    16910 5   AspNetUserRoles FK_AspNetUserRoles_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserRoles"
    ADD CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 c   ALTER TABLE ONLY public."AspNetUserRoles" DROP CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId";
       public          postgres    false    235    3368    237            T           2606    16915 7   AspNetUserTokens FK_AspNetUserTokens_AspNetUsers_UserId    FK CONSTRAINT     �   ALTER TABLE ONLY public."AspNetUserTokens"
    ADD CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES public."AspNetUsers"("Id") ON DELETE CASCADE;
 e   ALTER TABLE ONLY public."AspNetUserTokens" DROP CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId";
       public          postgres    false    236    3368    237            U           2606    16920 %   BillOrders FK_BillOrders_Bills_BillId    FK CONSTRAINT     �   ALTER TABLE ONLY public."BillOrders"
    ADD CONSTRAINT "FK_BillOrders_Bills_BillId" FOREIGN KEY ("BillId") REFERENCES public."Bills"("Id") ON DELETE CASCADE;
 S   ALTER TABLE ONLY public."BillOrders" DROP CONSTRAINT "FK_BillOrders_Bills_BillId";
       public          postgres    false    238    239    3376            V           2606    16925 '   BillOrders FK_BillOrders_Orders_OrderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."BillOrders"
    ADD CONSTRAINT "FK_BillOrders_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES public."Orders"("Id") ON DELETE CASCADE;
 U   ALTER TABLE ONLY public."BillOrders" DROP CONSTRAINT "FK_BillOrders_Orders_OrderId";
       public          postgres    false    238    246    3397            W           2606    16930 #   Bills FK_Bills_AspNetUsers_CasherId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Bills"
    ADD CONSTRAINT "FK_Bills_AspNetUsers_CasherId" FOREIGN KEY ("CasherId") REFERENCES public."AspNetUsers"("Id");
 Q   ALTER TABLE ONLY public."Bills" DROP CONSTRAINT "FK_Bills_AspNetUsers_CasherId";
       public          postgres    false    237    3368    239            X           2606    16935 %   Bills FK_Bills_AspNetUsers_CustomerId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Bills"
    ADD CONSTRAINT "FK_Bills_AspNetUsers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES public."AspNetUsers"("Id");
 S   ALTER TABLE ONLY public."Bills" DROP CONSTRAINT "FK_Bills_AspNetUsers_CustomerId";
       public          postgres    false    3368    237    239            Y           2606    16940 %   ItemImages FK_ItemImages_Items_ItemId    FK CONSTRAINT     �   ALTER TABLE ONLY public."ItemImages"
    ADD CONSTRAINT "FK_ItemImages_Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES public."Items"("Id") ON DELETE CASCADE;
 S   ALTER TABLE ONLY public."ItemImages" DROP CONSTRAINT "FK_ItemImages_Items_ItemId";
       public          postgres    false    3389    244    243            Z           2606    16945 $   Items FK_Items_Categories_CategoryId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "FK_Items_Categories_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES public."Categories"("Id") ON DELETE CASCADE;
 R   ALTER TABLE ONLY public."Items" DROP CONSTRAINT "FK_Items_Categories_CategoryId";
       public          postgres    false    3378    240    244            [           2606    16950 )   OrderDetails FK_OrderDetails_Items_ItemId    FK CONSTRAINT     �   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "FK_OrderDetails_Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES public."Items"("Id") ON DELETE CASCADE;
 W   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "FK_OrderDetails_Items_ItemId";
       public          postgres    false    245    3389    244            \           2606    16955 +   OrderDetails FK_OrderDetails_Orders_OrderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."OrderDetails"
    ADD CONSTRAINT "FK_OrderDetails_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES public."Orders"("Id") ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public."OrderDetails" DROP CONSTRAINT "FK_OrderDetails_Orders_OrderId";
       public          postgres    false    245    246    3397            ]           2606    16960 (   Orders FK_Orders_AspNetUsers_BartenderId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_AspNetUsers_BartenderId" FOREIGN KEY ("BartenderId") REFERENCES public."AspNetUsers"("Id") NOT VALID;
 V   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "FK_Orders_AspNetUsers_BartenderId";
       public          postgres    false    246    237    3368            ^           2606    16965 '   Orders FK_Orders_AspNetUsers_EmployeeId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_AspNetUsers_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES public."AspNetUsers"("Id");
 U   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "FK_Orders_AspNetUsers_EmployeeId";
       public          postgres    false    246    237    3368            _           2606    16970 +   Orders FK_Orders_AspNetUsers_UserRejectedId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_AspNetUsers_UserRejectedId" FOREIGN KEY ("UserRejectedId") REFERENCES public."AspNetUsers"("Id");
 Y   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "FK_Orders_AspNetUsers_UserRejectedId";
       public          postgres    false    3368    246    237            `           2606    16975    Orders FK_Orders_Tables_TableId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_Orders_Tables_TableId" FOREIGN KEY ("TableId") REFERENCES public."Tables"("Id");
 M   ALTER TABLE ONLY public."Orders" DROP CONSTRAINT "FK_Orders_Tables_TableId";
       public          postgres    false    248    3402    246            a           2606    16980    Tables FK_Tables_Floors_FloorId    FK CONSTRAINT     �   ALTER TABLE ONLY public."Tables"
    ADD CONSTRAINT "FK_Tables_Floors_FloorId" FOREIGN KEY ("FloorId") REFERENCES public."Floors"("Id") ON DELETE CASCADE;
 M   ALTER TABLE ONLY public."Tables" DROP CONSTRAINT "FK_Tables_Floors_FloorId";
       public          postgres    false    248    242    3383            �   R   x�3�,.I,)�JK��IM�2202�54�5��4�r�u�K+cS+#K=SKc#3.#\�t�:�|c�Nc��=... ��s      �   �   x����K�0�ϯE�QfIҮ��H�;Ld �d��yJ�k%Md �簾 z�����>�/���?_��յl_�[�u7�J�w�>I�Y8�%"
���#�pA.��
P��	��
��G-Ice��Qdz;��������5�Mڠy�-��6��yA~4tAO���~��?QQZT�^�Bd�,ϫ����{s/�Pwr���X�k���cB�2�E�����EΦ3��N��W�-s�C�$��	��      �   �   x�3�41�tK��IM�V
�,HU�RrI,ItN�+I-�N-*�LN-��tJL�.-��uj�t�|SK2�S�:!�sr@�@��Ģ��T�"���@ѱ@QǢ��\�^�@-gt,��������������������������!g��W� =`3�      �   p   x�3�4�JM.-*��K��O�L�TrJL�.-p��qI,IT�4�2*
��M�44372�4000�E��S�J�KsJJ�R9�@�M⡞(2�`�J�*��K�J8�b1z\\\ �p#�      �      x������ � �      �      x������ � �      �      x������ � �      �      x�34�����       �   �   x�Eʽ�  �<���4�q@a3>���ğ��뢱I����9�h�2z�9�dN�,��G�^s�Y�ID�/��<;��pZֻ���=+$��M�� ]�Ȝۣ­�C�k��� $҆4�#ڄ.�cC<ç���`xr`ס�J�/�*g      �   <   x�3�,JM.-*��K���O*�4437267310�tJL�.-p��qI,I���4������ �R�      �   �  x��M��D���_a�	$:�]U����.H `V�2��ݞ�M'A���j;�!���X�cb��ޮ~�Ue5Q���߷q�ɻv~w�X�C��j۶��]�۪,���Xo���
�BꙔ3	Sp����u�h���jv���R��_}u�s���ױ	�����|���vU���]Mn��G@e���Mh7��Gi��Ml���w5_rJ"I���v�f����1�j��b�Ծ��hb���;�q�Fx
^�����!T�1ڦ�9�o�|���zY�?�x����ŪJ��+Yo�5��m�j?�e�USl�Ǵ�ӬZc�v������5:�}�����}Zӛ��&~�����-?�↻t�ס���/��b�\<Qq߮�m���7qþ�ó⨑��eQaS�	��M\nb;M��s�������_��t�_�eq�n��'���>|�Z��e,����f�?��/q�>p���Pi��<u>N�}��y��d0m�G�ϳd��� _o�"<���Uy3��)h��0�Y�!��i��}�h�-6���l55 5(�)��ҥA>V@������l%�NY��l�XK��rG؂3��� �U�-�<gi�-�_M����ݹ�ȑ�� ��R�\�"�:W�Ord�\�,�~��NFA�+E Ԃ��ѡu/@�KW/Ws^�t%�/tХ�^x^�yp��x������������%|�9O�� _� ��N��9 ���<_l���|q%Z��`�I'�PE�*5��X�^���^��du���V�_�|�#|�Y|=�wv�/d���K��l_Iqh�p��B`�/w����upy��}ı�C�K��H�š��[0*�ve���q��咷�d�Jj�R��_�,��<h�76ϗ1Nw-O��.M�N��/�f�N-�m�_�O�N6v�p�y��}�����T���R�eM�5��ecu~�����\��Ο_I������c�s_�<���P!�t� _]�v|�d�0C�*��0ϗ�vA97�ש�F� $k�|u�����R��Ҫ�'��P4A7�t�򦯮a���N���/�%��ԅ�C���7�9|��з%���ph����W8����)966�����;�IPY�:��c��+ ]:��F�:�dQP��=���Ɲo�r�,�և���mr��/<6�p��σ3y��nD-i����t����������:	|�։��(������A"8?���w����k���^��V����^�|=���|�>_Oy@T���[ś���d��7x�|�!W3�������q0�C�o��k��d�����/p���� ��u�EM0�A]���s���kR�9�:��2��a��xC����)^:���Ѡ8O|�y�;:����ʩ6�@�����7����8�ξ�����ys����5`��کu��`��W�^���}             x������ � �         D   x�st����tD'���B\�\\�8񲸜�=<�"8h.���_� N��o����+'nW� 5,�            x������ � �            x������ � �         8   x��LLN6O4L�ML�0�5I5MԵHN2�5H2170251�HL�tt�������� Bd�            x������ � �         �   x�u�MN�@ ���Sp���������ViI���f~`D-�B�+�� �Dc׾��{�V/3�	�4A2H3P:+ �T �(�Ɓ������@}�"b`:JɈ�!G�_o�~{ jZ�5X�5ը��JM\�ʇM���,�զ���һE�,'���X_�����/]{ڇ���m������~������,�e*h[��mEg%l~�Y�5�u� ^D셠P�H �Ìy�e!噷8��_쁒�0I��P      	      x������ � �      
      x������ � �            x������ � �            x������ � �            x������ � �            x������ � �            x������ � �            x������ � �            x������ � �         *   x��rq�ruv�s⌎������9����b���� �
O            x������ � �         $   x�3202244020762��7�4�3�3����� N�     