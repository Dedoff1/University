--
-- PostgreSQL database dump
--

-- Dumped from database version 17.0
-- Dumped by pg_dump version 17.0

-- Started on 2024-12-03 04:44:24

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 221 (class 1259 OID 16501)
-- Name: Carts; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Carts" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "Quantity" integer NOT NULL,
    "AddedAt" timestamp with time zone NOT NULL,
    "ModifiedAt" timestamp with time zone NOT NULL
);


ALTER TABLE public."Carts" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 24588)
-- Name: Feedbacks; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Feedbacks" (
    "Id" uuid NOT NULL,
    "ProductId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "Comment" text
);


ALTER TABLE public."Feedbacks" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16475)
-- Name: Products; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Products" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Price" numeric NOT NULL,
    "Category" text NOT NULL,
    "Description" text NOT NULL,
    "Image" bytea NOT NULL
);


ALTER TABLE public."Products" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16482)
-- Name: Roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Roles" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL
);


ALTER TABLE public."Roles" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16489)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "LastLogin" timestamp with time zone NOT NULL,
    "IsActive" boolean NOT NULL,
    "RoleId" uuid NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16470)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 4767 (class 2606 OID 16505)
-- Name: Carts PK_Carts; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "PK_Carts" PRIMARY KEY ("Id");


--
-- TOC entry 4771 (class 2606 OID 24594)
-- Name: Feedbacks PK_Feedbacks; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Feedbacks"
    ADD CONSTRAINT "PK_Feedbacks" PRIMARY KEY ("Id");


--
-- TOC entry 4758 (class 2606 OID 16481)
-- Name: Products PK_Products; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Products"
    ADD CONSTRAINT "PK_Products" PRIMARY KEY ("Id");


--
-- TOC entry 4760 (class 2606 OID 16488)
-- Name: Roles PK_Roles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "PK_Roles" PRIMARY KEY ("Id");


--
-- TOC entry 4763 (class 2606 OID 16495)
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- TOC entry 4756 (class 2606 OID 16474)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4764 (class 1259 OID 16516)
-- Name: IX_Carts_ProductId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Carts_ProductId" ON public."Carts" USING btree ("ProductId");


--
-- TOC entry 4765 (class 1259 OID 16517)
-- Name: IX_Carts_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Carts_UserId" ON public."Carts" USING btree ("UserId");


--
-- TOC entry 4768 (class 1259 OID 24605)
-- Name: IX_Feedbacks_ProductId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Feedbacks_ProductId" ON public."Feedbacks" USING btree ("ProductId");


--
-- TOC entry 4769 (class 1259 OID 24606)
-- Name: IX_Feedbacks_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Feedbacks_UserId" ON public."Feedbacks" USING btree ("UserId");


--
-- TOC entry 4761 (class 1259 OID 16518)
-- Name: IX_Users_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Users_RoleId" ON public."Users" USING btree ("RoleId");


--
-- TOC entry 4773 (class 2606 OID 16506)
-- Name: Carts FK_Carts_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "FK_Carts_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- TOC entry 4774 (class 2606 OID 16511)
-- Name: Carts FK_Carts_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "FK_Carts_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- TOC entry 4775 (class 2606 OID 24595)
-- Name: Feedbacks FK_Feedbacks_Products_ProductId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Feedbacks"
    ADD CONSTRAINT "FK_Feedbacks_Products_ProductId" FOREIGN KEY ("ProductId") REFERENCES public."Products"("Id") ON DELETE CASCADE;


--
-- TOC entry 4776 (class 2606 OID 24600)
-- Name: Feedbacks FK_Feedbacks_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Feedbacks"
    ADD CONSTRAINT "FK_Feedbacks_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


--
-- TOC entry 4772 (class 2606 OID 16496)
-- Name: Users FK_Users_Roles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "FK_Users_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE;


-- Completed on 2024-12-03 04:44:25

--
-- PostgreSQL database dump complete
--

